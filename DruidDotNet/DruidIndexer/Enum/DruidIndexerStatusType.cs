namespace DruidDotNet.DruidIndexer
{
    internal static class DruidIndexerStatusType
    {
        public const string Running = "RUNNING";
        public const string Success = "SUCCESS";
        public const string Failed = "FAILED";

        public static IndexerStatus GetStatus(string status, bool ended = false)
        {
            switch (status)
            {
                case Running:
                    return ended ? IndexerStatus.Pending : IndexerStatus.Running;
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
