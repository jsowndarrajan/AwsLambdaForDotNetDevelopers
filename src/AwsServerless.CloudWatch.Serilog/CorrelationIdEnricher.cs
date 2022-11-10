using Serilog.Core;
using Serilog.Events;

namespace AwsServerless.CloudWatch.Serilog;

public class CorrelationIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(nameof(CorrelationId), CorrelationId.Get()));
    }
}