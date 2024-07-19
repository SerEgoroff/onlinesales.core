using System.Runtime.Serialization;
using SalesPro.Interfaces;

namespace SalesPro.Exceptions;

[Serializable]
public class TaskNotCompletedException : Exception
{
    public TaskNotCompletedException()
        : base("Another task is not comleted yet")
    {
    }
}