using System;
using System.Collections.Generic;
using System.Text;

namespace ZavenDotNetInterview.Common.ViewModels
{
    public class LogViewModel
    {
        public string Description { get; set; }
        public Guid JobId { get; set; }
        public JobViewModel Job { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
