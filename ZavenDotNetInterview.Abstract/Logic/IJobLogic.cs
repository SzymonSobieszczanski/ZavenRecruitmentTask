using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZavenDotNetInterview.Common.ViewModels;

namespace ZavenDotNetInterview.Abstract.Logic
{
    public interface IJobLogic 
    {
        JobViewModel Get(Guid id);
        IEnumerable<JobViewModel> GetAll();
        Guid Add(JobViewModel entity);
        Task<bool> ProcessJobs();
        bool IsUniqueName(string name);
    }
}
