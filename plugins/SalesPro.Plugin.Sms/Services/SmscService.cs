using System.Reflection;
using System.Web;
using Newtonsoft.Json;
using SalesPro.Plugin.Sms.Configuration;
using SalesPro.Plugin.Sms.Exceptions;
using Serilog;

namespace SalesPro.Plugin.Sms.Services;

public class SmscService : ISmsService
{
    private readonly SmscConfig smscConfig;

    public SmscService(SmscConfig smscConfig)
    {
        this.smscConfig = smscConfig;
    }

    public async Task SendAsync(string recipient, string message)
    {
        var responseString = string.Empty;
        var args =
            $"login={HttpUtility.UrlEncode(smscConfig.Login)}" +
            $"&psw={HttpUtility.UrlEncode(smscConfig.Password)}" +
            $"&phones={HttpUtility.UrlEncode(recipient)}" +
            $"&mes={HttpUtility.UrlEncode(message)}" +
            $"&sender={HttpUtility.UrlEncode(smscConfig.SenderId)}" +
            "&fmt=3" + // Use JSON return format
            "&charset=utf-8";

        using (var httpClient = new HttpClient())
        {
            var response = await httpClient.GetAsync(smscConfig.ApiUrl + "?" + args);
            responseString = await response.Content.ReadAsStringAsync();
        }

        dynamic? jsonResponseObject = JsonConvert.DeserializeObject(responseString);
        if (jsonResponseObject != null && jsonResponseObject!["error"] != null)
        {
            throw new SmscException($"Failed to send message to {recipient} ( {jsonResponseObject!["error"]} )");
        }
    }

    public string GetSender(string recipient)
    {
        return smscConfig.SenderId;
    }
}