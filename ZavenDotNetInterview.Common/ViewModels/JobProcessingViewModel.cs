using System;
using System.Collections.Generic;
using System.Text;
using ZavenDotNetInterview.Common.Enums;

namespace ZavenDotNetInterview.Common.ViewModels
{
    public class JobProcessingViewModel
    {
        public Guid Id { get; set; }
        public JobStatus Status { get; set; }
    }
}
