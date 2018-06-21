using System;
using System.Threading.Tasks;
using System.Timers;
using DruidDotNet.DruidIndexer.Spec;
using Refit;

namespace DruidDotNet.DruidIndexer
{
    public class DruidIndexer : IDruidIndexer
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
            string status;

            do
            {
                status = await Status(id);
            } while (status == DruidIndexerStatusType.Running && timer.Enabled);

            return DruidIndexerStatusType.GetStatus(status, true);
        }

        public async Task<string> Index(IndexSpec indexSpec)
        {
            return await RestService.For<IDruidIndexer>(_baseUrl).Index(indexSpec);
        }

        public async Task<string> Status(string id)
        {
            return await RestService.For<IDruidIndexer>(_baseUrl).Status(id);
        }
    }
}
