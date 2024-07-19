using Microsoft.Extensions.Configuration;
using SalesPro.Configuration;
using SalesPro.Data;
using SalesPro.DataAnnotations;
using SalesPro.DTOs;
using SalesPro.Entities;
using SalesPro.Exceptions;
using SalesPro.Helpers;
using SalesPro.Plugin.SendGrid.Data;
using SalesPro.Plugin.SendGrid.Entities;
using SalesPro.Plugin.SendGrid.Exceptions;
using SalesPro.Services;
using SalesPro.Tasks;
using Serilog;

namespace SalesPro.SendGrid.Tasks
{
    public class SyncActivityLogTask : BaseTask
    {
        private static readonly string SourceName = "SendGrid";

        private readonly SendgridDbContext sgDbContext;

        private readonly ActivityLogService logService;

        private readonly int batchSize;

        public SyncActivityLogTask(IConfiguration configuration, SendgridDbContext dbContext, TaskStatusService taskStatusService, ActivityLogService logService)
            : base("Tasks:SyncActivityLogTask", configuration, taskStatusService)
        {
            sgDbContext = dbContext;
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
                var events = sgDbContext.SendgridEvents!.Where(e => e.Id > maxId).OrderBy(e => e.Id).Take(batchSize).Select(e => Convert(e)).ToList();
                var res = await logService.AddActivityRecords(events);
                if (!res)
                {
                    throw new SendGridApiException("Cannot log sendgrid events");
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Error("Error while logging sendgrid events. Reason: " + ex.Message);
                throw;
            }
        }

        private static ActivityLog Convert(SendgridEvent ev)
        {
            return new ActivityLog()
            {
                Source = SourceName,
                SourceId = ev.Id,
                Type = ev.Event,
                CreatedAt = ev.CreatedAt,
                ContactId = ev.ContactId,
                Ip = ev.Ip,
                Data = JsonHelper.Serialize(new { Id = ev.Id, MessageId = ev.MessageId, EventId = ev.EventId }),
            };
        }
    }
}