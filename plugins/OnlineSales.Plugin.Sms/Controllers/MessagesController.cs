﻿// <copyright file="MessagesController.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSales.Plugin.Sms.Data;
using OnlineSales.Plugin.Sms.DTOs;
using OnlineSales.Plugin.Sms.Entities;
using Serilog;

namespace OnlineSales.Plugin.Sms.Controllers;

[Route("api/messages")]
public class MessagesController : Controller
{
    private readonly ISmsService smsService;
    private readonly SmsControllerHelper controllerHelper;

    public MessagesController(SmsDbContext dbContext, ISmsService smsService)
    {
        this.smsService = smsService;

        controllerHelper = new SmsControllerHelper(dbContext);
    }

    [HttpPost]
    [Route("sms")]
    [AllowAnonymous] // @@ why?
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SendSms(
        [FromBody] SmsDetailsDto smsDetails,
        [FromHeader(Name = "Authentication")] string accessToken)
    {
        try
        {
            SmsControllerHelper.CheckAuthentication(accessToken);
            var recipient = controllerHelper.GetRecipient(smsDetails.Recipient, ModelState);

            var smsLog = await controllerHelper.AddLog(recipient, smsService.GetSender(recipient), smsDetails.Message);

            await smsService.SendAsync(recipient, smsDetails.Message);

            await controllerHelper.UpdateLogStatus(smsLog, SmsLog.SmsStatus.Sent);

            return Ok();
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Failed to send SMS message to {0}: {1}", smsDetails.Recipient, smsDetails.Message);

            throw;
        }
    }
}