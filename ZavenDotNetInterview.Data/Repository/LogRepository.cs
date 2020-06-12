using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZavenDotNetInterview.Abstract;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.Data.Repository
{
    public class LogRepository : Repository<Log>, ILogRepository
    {
        public LogRepository(DbContext context) : base(context)
        {

        }

        public async Task AddAsync(Log log)
        {
           await Context.AddAsync(log);
        }
    }
}
