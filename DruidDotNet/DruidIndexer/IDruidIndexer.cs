using DruidDotNet.DruidIndexer.Spec;
using Refit;
using System.Threading.Tasks;

namespace DruidDotNet.DruidIndexer
{
    public interface IDruidIndexer
    {
        [Post("druid/indexer/v1/task")]
        Task<string> Index(IndexSpec indexSpec);

        [Get("druid/indexer/v1/task/{id}/status")]
        Task<string> Status(string id);
    }
}
