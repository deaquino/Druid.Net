using DruidDotNet.DruidIndexer.Spec;
using Refit;
using System.Threading.Tasks;

namespace DruidDotNet.DruidIndexer
{
    internal interface IDruidIndexer
    {
        [Post("/druid/indexer/v1/task")]
        Task<IndexResult> Index(IndexSpec indexSpec);

        [Get("/druid/indexer/v1/task/{id}/status")]
        Task<StatusResult> Status(string id);
    }

    internal class IndexResult
    {
        public string Task { get; set; }
    }

    internal class StatusResult : IndexResult
    {
        public IndexStatus Status { get; set; }
    }

    internal class IndexStatus
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public int Duration { get; set; }

    }

}
