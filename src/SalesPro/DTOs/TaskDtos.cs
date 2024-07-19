namespace SalesPro.DTOs;

public class TaskDetailsDto
{
    public string Name { get; set; } = string.Empty;

    public string CronSchedule { get; set; } = string.Empty;

    public int RetryCount { get; set; }

    public int RetryInterval { get; set; }

    public bool IsRunning { get; set; }
}

public class TaskExecutionDto
{
    public string Name { get; set; } = string.Empty;

    public bool Completed { get; set; } = false;
}