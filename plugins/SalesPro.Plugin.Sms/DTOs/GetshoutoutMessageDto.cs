﻿namespace SalesPro.Plugin.Sms.DTOs;

public class GetshoutoutMessageDto
{
    public string Source { get; set; } = string.Empty;

    public List<string> Destinations { get; set; } = new List<string>();

    public List<string> Transports { get; set; } = new List<string> { "sms" };

    public Content Content { get; set; } = new Content();
}

public class Content
{
    public string Sms { get; set; } = string.Empty;
}