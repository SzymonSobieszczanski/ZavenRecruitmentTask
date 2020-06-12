using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.Abstract
{
    public interface ILogRepository : IRepository<Log>
    {
        Task AddAsync(Log log);
    }
}
