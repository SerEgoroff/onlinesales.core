﻿using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using SalesPro.Plugin.Sms.Configuration;
using SalesPro.Plugin.Sms.Exceptions;
using Serilog;

namespace SalesPro.Plugin.Sms.Services;

public class AmazonSnsGatewayService : ISmsService
{
    private readonly AmazonSnsConfig amazonSns;

    public AmazonSnsGatewayService(AmazonSnsConfig amazonSns)
    {
        this.amazonSns = amazonSns;
    }

    public async Task SendAsync(string recipient, string message)
    {
        var accessKey = amazonSns.AccessKeyId;
        var secretKey = amazonSns.SecretAccessKey;
        var region = RegionEndpoint.GetBySystemName(amazonSns.DefaultRegion);

        var client = new AmazonSimpleNotificationServiceClient(accessKey, secretKey, region);
        var messageAttributes = new Dictionary<string, MessageAttributeValue>();

        messageAttributes["AWS.SNS.SMS.SMSType"] = new MessageAttributeValue
        {
            DataType = "String",
            StringValue = "Transactional",
        };

        messageAttributes["AWS.SNS.SMS.SenderID"] = new MessageAttributeValue
        {
            DataType = "String",
            StringValue = amazonSns.SenderId,
        };

        var request = new PublishRequest
        {
            Message = message,
            PhoneNumber = recipient,
            MessageAttributes = messageAttributes,
        };

        var response = await client.PublishAsync(request);

        if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
        {
            throw new AwsSnsException("Failed to send Messages through SNS : Receiver : {" + recipient + "} St : { " + response.HttpStatusCode.ToString() + " }");
        }

        Log.Information("Sms message sent to {0} via AmazonSns gateway: {1} HttpStatus Code {2} Message Id {3}", recipient, message, response.HttpStatusCode.ToString(), response.MessageId.ToString());
    }

    public string GetSender(string recipient)
    {
        return amazonSns.SenderId;
    }
}