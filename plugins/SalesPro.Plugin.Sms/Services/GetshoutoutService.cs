using System.Net.Http.Headers;
using SalesPro.Helpers;
using SalesPro.Plugin.Sms.Configuration;
using SalesPro.Plugin.Sms.DTOs;
using SalesPro.Plugin.Sms.Exceptions;
using Serilog;

namespace SalesPro.Plugin.Sms.Services;

public class GetshoutoutService : ISmsService
{
    private readonly GetshoutoutConfig getshoutoutConfig;

    public GetshoutoutService(GetshoutoutConfig getshoutoutConfig)
    {
        this.getshoutoutConfig = getshoutoutConfig;
    }

    public async Task SendAsync(string recipient, string message)
    {
        var client = new HttpClient();
        client.BaseAddress = new Uri(getshoutoutConfig.ApiUrl);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", "Apikey " + getshoutoutConfig.ApiKey);

        var messageDto = new GetshoutoutMessageDto
        {
            Source = getshoutoutConfig.SenderId,
            Content = new Content
            {
                Sms = message,
            },
            Destinations = new List<string>
            {
                recipient.Substring(1, recipient.Length - 1), // removes "+" in front of the number as the Getshoutout does not want it
            },
        };

        var messageDtoJson = JsonHelper.Serialize(messageDto);
        var content = new StringContent(messageDtoJson, new MediaTypeHeaderValue("application/json"));

        var result = await client.PostAsync("/coreservice/messages", content);

        if (result.IsSuccessStatusCode)
        {
            Log.Information("Sms message sent to {0} via Getshoutout gateway: {1}", recipient, message);
        }
        else
        {
            var responseContent = await result.Content.ReadAsStringAsync();

            throw new GetshoutoutException(responseContent);
        }
    }

    public string GetSender(string recipient)
    {
        return getshoutoutConfig.SenderId;
    }
}