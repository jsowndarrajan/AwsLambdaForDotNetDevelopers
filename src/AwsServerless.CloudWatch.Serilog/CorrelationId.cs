namespace AwsServerless.CloudWatch.Serilog
{
    public static class CorrelationId
    {
        private static string? _correlationId;

        public static string Get()
        {
            if (_correlationId is null)
            {
                _correlationId = Guid.NewGuid().ToString();
            }
            return _correlationId;
        }

        public static void Set(string correlationId)
        {
            _correlationId = correlationId;
        }
    }
}
