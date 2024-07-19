using Nest;
using SalesPro.Data;
using SalesPro.Entities;

namespace SalesPro.Services
{
    public class ActivityLogService
    {
        private readonly string indexName;

        private readonly EsDbContext esDbContext;

        public ActivityLogService(IConfiguration configuration, EsDbContext esDbContext)
        {
            indexName = configuration.GetSection("Elastic:IndexPrefix").Get<string>() + "-activitylog";
            this.esDbContext = esDbContext;
        }

        public async Task<int> GetMaxId(string source)
        {
            var sr = new SearchRequest<ActivityLog>(indexName);
            sr.Query = new TermQuery() { Field = "source.keyword", Value = source };
            sr.Sort = new List<ISort>() { new FieldSort { Field = "sourceId", Order = Nest.SortOrder.Descending } };
            sr.Size = 1;
            var res = await esDbContext.ElasticClient.SearchAsync<ActivityLog>(sr);
            if (res != null)
            {
                var doc = res.Documents.FirstOrDefault();
                if (doc != null)
                {
                    return doc.SourceId;
                }
            }

            return 0;
        }

        public async Task<bool> AddActivityRecords(List<ActivityLog> records)
        {
            if (records.Count > 0)
            {
                var responce = await esDbContext.ElasticClient.IndexManyAsync<ActivityLog>(records, indexName);

                if (!responce.IsValid)
                {
                    Log.Error("Cannot save logs in Elastic Search. Reason: " + responce.DebugInformation);
                }

                return responce.IsValid;
            }
            else
            {
                return true;
            }
        }
    }
}