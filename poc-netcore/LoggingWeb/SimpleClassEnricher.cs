using System.Collections.Generic;
using Serilog.Core;
using Serilog.Events;

namespace LoggingWeb
{
    class SimpleClassEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var logEventPropertyValue = logEvent.Properties.GetValueOrDefault("SourceContext");
            var typeName = logEventPropertyValue?.ToString();
            if (string.IsNullOrEmpty(typeName))
                return;

            var pos = typeName.LastIndexOf('.');
            typeName = typeName.Substring(pos + 1, typeName.Length - pos - 2);
            logEvent.AddOrUpdateProperty(propertyFactory.CreateProperty("SourceContext", typeName));
        }
    }
}