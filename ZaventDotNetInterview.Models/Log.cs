using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZaventDotNetInterview.Models;

namespace ZavenDotNetInterview.App.Models
{
    public class Log : BaseEntityModel
    {
        public string Description { get; set; }
        public Guid JobId { get; set; }
        public virtual Job Job { get; set; }
    }
}