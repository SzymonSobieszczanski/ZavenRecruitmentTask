using System;
using System.Collections.Generic;
using System.Text;

namespace ZavenDotNetInterview.Abstract
{
    public interface IUnitOFWork : IDisposable
    {
        IJobRepository Jobs { get; set; }
        ILogRepository Logs { get; set; }
    }
}
