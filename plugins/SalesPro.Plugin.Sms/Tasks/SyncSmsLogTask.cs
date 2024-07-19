using Microsoft.Extensions.Configuration;
using SalesPro.Configuration;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Exceptions;
using SalesPro.Helpers;
using SalesPro.Plugin.Sms.Data;
using SalesPro.Plugin.Sms.Entities;
using SalesPro.Plugin.Sms.Exceptions;
using SalesPro.Services;
using SalesPro.Tasks;
using Serilog;

namespace SalesPro.Plugin.Sms.Tasks
{
    public class SyncSmsLogTask : BaseTask
    {
        private static readonly string SourceName = "SMS";

        private readonly SmsDbContext dbContext;

        private readonly ActivityLogService logService;

        private readonly int batchSize;

        public SyncSmsLogTask(IConfiguration configuration, SmsDbContext dbContext, TaskStatusService taskStatusService, ActivityLogService logService)
            : base("Tasks:SyncSmsLogTask", configuration, taskStatusService)
        {
            this.dbContext = dbContext;
            this.logService = logService;
            var config = configuration.GetSection(configKey)!.Get<TaskWithBatchConfig>();
            if (config is not null)
            {
                batchSize = config.BatchSize;
            }
            else
            {
                throw new MissingConfigurationException($"The specified configuration section for the provided configKey {configKey} could not be found in the settings file.");
            }
        }

        public async override Task<bool> Execute(TaskExecutionLog currentJob)
        {
            try
            {
                var maxId = await logService.GetMaxId(SourceName);
                var events = dbContext.SmsLogs!.Where(e => e.Id > maxId).OrderBy(e => e.Id).Take(batchSize).Select(e => Convert(e)).ToList();
                var res = await logService.AddActivityRecords(events);
                if (!res)
                {
                    throw new SmsPluginException("Unable to log sms plugin events");
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Failed to dump sms plugin events to activity log. Reason: " + ex.Message);
                throw;
            }
        }

        private static ActivityLog Convert(SmsLog ev)
        {
            return new ActivityLog()
            {
                Source = SourceName,
                SourceId = ev.Id,
                Type = "Message",
                CreatedAt = ev.CreatedAt,
                Data = JsonHelper.Serialize(new { Id = ev.Id, Status = ev.Status, Sender = ev.Sender, Recipient = ev.Recipient }),
            };
        }
    }
}