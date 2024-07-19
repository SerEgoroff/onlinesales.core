﻿using Microsoft.Extensions.Configuration;
using SalesPro.Plugin.Sms.Configuration;
using SalesPro.Plugin.Sms.Exceptions;

namespace SalesPro.Plugin.Sms.Services;

public class SmsService : ISmsService
{
    private readonly PluginConfig pluginSettings = new PluginConfig();
    private readonly Dictionary<string, ISmsService> countrySmsServices = new Dictionary<string, ISmsService>();

    public SmsService(IConfiguration configuration)
    {
        var settings = configuration.Get<PluginConfig>();

        if (settings != null)
        {
            pluginSettings = settings;
            InitGateways();
        }
    }

    public Task SendAsync(string recipient, string message)
    {
        var smsService = GetSmsService(recipient);

        if (smsService == null)
        {
            throw new UnknownCountryCodeException();
        }

        return smsService.SendAsync(recipient, message);
    }

    public string GetSender(string recipient)
    {
        var smsService = GetSmsService(recipient);

        return smsService != null ? smsService.GetSender(recipient) : string.Empty;
    }

    private ISmsService? GetSmsService(string recipient)
    {
        var key = countrySmsServices.Keys.FirstOrDefault(key => recipient.StartsWith(key));

        if (key != null)
        {
            return countrySmsServices[key];
        }

        if (countrySmsServices.TryGetValue("default", out var smsService))
        {
            return smsService;
        }

        return null;
    }

    private void InitGateways()
    {
        foreach (var countryGateway in pluginSettings.SmsCountryGateways)
        {
            ISmsService? gatewayService = null;

            var gatewayName = countryGateway.Gateway;

            switch (gatewayName)
            {
                case "Smsc":
                    gatewayService = new SmscService(pluginSettings.SmsGateways.Smsc);
                    break;
                case "SmscKz":
                    gatewayService = new SmscService(pluginSettings.SmsGateways.SmscKz);
                    break;
                case "NotifyLk":
                    gatewayService = new NotifyLkService(pluginSettings.SmsGateways.NotifyLk);
                    break;
                case "Getshoutout":
                    gatewayService = new GetshoutoutService(pluginSettings.SmsGateways.Getshoutout);
                    break;
                case "AmazonSns":
                    gatewayService = new AmazonSnsGatewayService(pluginSettings.SmsGateways.AmazonSns);
                    break;
                case "Twilio":
                    gatewayService = new TwilioService(pluginSettings.SmsGateways.Twilio);
                    break;
            }

            if (gatewayService != null)
            {
                countrySmsServices[countryGateway.Code] = gatewayService;
            }
        }
    }
}