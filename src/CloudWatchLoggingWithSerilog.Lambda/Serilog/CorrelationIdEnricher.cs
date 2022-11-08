using Serilog.Core;
using Serilog.Events;

namespace CloudWatchLoggingWithSerilog.Lambda.Serilog;

public class CorrelationIdEnricher : ILogEventEnricher
{
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(nameof(CorrelationId), CorrelationId.Get()));
    }
}