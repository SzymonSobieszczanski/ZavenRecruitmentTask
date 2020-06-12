using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ZavenDotNetInterview.Common.Enums;

namespace ZavenDotNetInterview.Common.ViewModels
{
    public class JobViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public JobStatus Status { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Please enter a valid date.")]
        public DateTime? DoAfter { get; set; }
        public List<LogViewModel> Logs { get; set; } = new List<LogViewModel>();
        public DateTime CreatedAt { get; set; }
    }
}
