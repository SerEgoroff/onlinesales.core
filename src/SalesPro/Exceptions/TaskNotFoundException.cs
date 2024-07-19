using System.Runtime.Serialization;

namespace SalesPro.Exceptions;

[Serializable]
public class TaskNotFoundException : Exception
{
    public TaskNotFoundException(string taskName)
    {
        TaskName = taskName;
    }

    public string TaskName { get; }
}