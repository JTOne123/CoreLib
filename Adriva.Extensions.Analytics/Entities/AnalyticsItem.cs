using System;
using System.Collections.Generic;
using Adriva.AppInsights;
using Adriva.AppInsights.Serialization.Contracts;

namespace Adriva.Extensions.Analytics.Entities
{
    public class AnalyticsItem
    {
        public long Id { get; set; }

        public string InstrumentationKey { get; set; }

        public DateTime Timestamp { get; set; }

        public string ApplicationVersion { get; set; }

        public string RoleInstance { get; set; }

        public string OperationId { get; set; }

        public string ParentOperationId { get; set; }

        public string Ip { get; set; }

        public string SdkVersion { get; set; }

        public string Type { get; set; }

        public string UserId { get; set; }

        public string UserAccountId { get; set; }

        public string AuthenticatedUserId { get; set; }

        public List<ExceptionItem> Exceptions { get; set; } = new List<ExceptionItem>();

        public RequestItem RequestItem { get; set; }

        public MessageItem MessageItem { get; set; }

        public List<MetricItem> Metrics { get; set; } = new List<MetricItem>();

        public List<EventItem> Events { get; set; } = new List<EventItem>();

        public List<DependencyItem> Dependencies { get; set; } = new List<DependencyItem>();

        public override string ToString() => $"AnalyticsItem, [{this.Type}]";
    }
}