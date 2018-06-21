using System;
using System.Threading.Tasks;
using System.Timers;
using DruidDotNet.DruidIndexer.Enum;
using DruidDotNet.DruidIndexer.Spec;
using Refit;

namespace DruidDotNet.DruidIndexer
{
    public class DruidIndexer
    {
        private readonly string _baseUrl;

        public DruidIndexer(string baseUrl)
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
            return await RestService.For<IDruidIndexer>(_baseUrl).Index(indexSpec);
        }

        public async Task<IndexerStatus> Status(string id)
        {
            var status = await RestService.For<IDruidIndexer>(_baseUrl).Status(id);
            return DruidIndexerStatusType.GetStatus(status);
        }
    }
}
