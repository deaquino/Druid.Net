using System;
using System.Threading.Tasks;
using System.Timers;
using Druid.Net.DruidIndexer.Enum;
using Druid.Net.DruidIndexer.Spec;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace Druid.Net.DruidIndexer
{
    public class IndexerClient
    {
        private readonly string _baseUrl;

        public IndexerClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<IndexerStatus> IndexAndWait(IndexSpec indexSpec, TimeSpan maxWait)
        {
            var timer = new Timer(maxWait.TotalMilliseconds);
            timer.Elapsed += (sender, args) => { ((Timer)sender).Stop(); };
            timer.Start();

            var id = await Index(indexSpec);
            IndexerStatus status;

            do
            {
                status = await Status(id);
            } while (status == IndexerStatus.Running && timer.Enabled);

            return status == IndexerStatus.Running ? IndexerStatus.Pending : status;
        }

        public async Task<string> Index(IndexSpec indexSpec)
        {
            return (await GetIndexer().Index(indexSpec)).Task;
        }

        public async Task<IndexerStatus> Status(string id)
        {
            var status = await GetIndexer().Status(id);
            return DruidIndexerStatusType.GetStatus(status.Status.Status);
        }

        private IDruidIndexer GetIndexer()
        {
            return RestService.For<IDruidIndexer>(_baseUrl, new RefitSettings
            {
                JsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            });
        }
    }
}
