namespace Ayo.Core.Storage.Mongodb
{
    internal static class MongodbMapper
    {
        private static volatile bool _mappedBefore;
        private static readonly object _syncObj = new object();

        public static void CreateMappings()
        {
            lock (_syncObj)
            {
                if (_mappedBefore)
                    return;

                CreateMappingsInternal();

                _mappedBefore = true;
            }
        }

        private static void CreateMappingsInternal()
        {
        }
    }
}