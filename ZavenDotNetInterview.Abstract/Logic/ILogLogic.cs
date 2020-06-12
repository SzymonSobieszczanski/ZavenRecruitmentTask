using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZavenDotNetInterview.Common.Enums;
using ZavenDotNetInterview.Common.ViewModels;

namespace ZavenDotNetInterview.Abstract.Logic
{
    public interface ILogLogic
    {
        void CreatingLog(Guid id);
        Task UpdatingLog(Guid id, JobStatus status);
    }
}
