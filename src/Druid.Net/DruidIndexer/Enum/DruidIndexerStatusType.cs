namespace Druid.Net.DruidIndexer.Enum
{
    internal static class DruidIndexerStatusType
    {
        public const string Running = "RUNNING";
        public const string Success = "SUCCESS";
        public const string Failed = "FAILED";

        public static IndexerStatus GetStatus(string status)
        {
            switch (status)
            {
                case Running:
                    return IndexerStatus.Running;
                case Success:
                    return IndexerStatus.Success;
                case Failed:
                    return IndexerStatus.Failed;
                default:
                    return IndexerStatus.Unknown;
            }
        }
    }
}
