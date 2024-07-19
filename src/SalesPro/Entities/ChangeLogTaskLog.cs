﻿using System.ComponentModel.DataAnnotations.Schema;

namespace SalesPro.Entities;

public enum TaskExecutionState
{
    InProgress = 0,
    Completed = 1,
    Failed = 2,
}

[Table("change_log_task_log")]
public class ChangeLogTaskLog : BaseEntityWithId
{
    public string TaskName { get; set; } = string.Empty;

    public int ChangeLogIdMin { get; set; }

    public int ChangeLogIdMax { get; set; }

    public TaskExecutionState State { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int ChangesProcessed { get; set; }
}