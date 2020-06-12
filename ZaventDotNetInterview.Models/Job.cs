using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavenDotNetInterview.Common.Enums;
using ZaventDotNetInterview.Models;

namespace ZavenDotNetInterview.App.Models
{
    public class Job : BaseEntityModel
    {
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        public DateTime? DoAfter { get; set; }
        public ICollection<Log> Logs { get; set; }
        public int FailedCount { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}