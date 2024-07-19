using SalesPro.Entities;

namespace SalesPro.Interfaces
{
    public interface ITask
    {
        public string Name { get; }

        /// <summary>
        /// Gets cron expression based schedule.
        /// </summary>
        public string CronSchedule { get; }

        public int RetryCount { get; }

        /// <summary>
        /// Gets retry interval in minutes.
        /// </summary>
        public int RetryInterval { get; }

        public bool IsRunning { get; }

        public void SetRunning(bool running);

        Task<bool> Execute(TaskExecutionLog currentJob);
    }
}