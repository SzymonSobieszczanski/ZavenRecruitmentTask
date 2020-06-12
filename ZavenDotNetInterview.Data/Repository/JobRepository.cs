using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZavenDotNetInterview.Abstract;
using ZavenDotNetInterview.App.Models;
using static ZavenDotNetInterview.Common.Enums.JobStatus;

namespace ZavenDotNetInterview.Data.Repository
{
    public class JobRepository : Repository<Job>,IJobRepository
    {
        private ApplicationDbContext Context;
        public JobRepository(ApplicationDbContext context) : base(context)
        {
            Context = context;
        }
        public override Job Get(Guid id)
        {
            return Context.Jobs.Include(i => i.Logs).FirstOrDefault(j => j.Id == id);
        }

        public IQueryable<Job> GetAllQueryable()
        {
            return Context.Jobs.AsQueryable();
        }
        public  List<Job> GetJobToProcess()
        {
            return Context.Jobs.Where(p =>
                p.FailedCount < 5 && (p.DoAfter == null || p.DoAfter.Value < DateTime.Now) &&
                (p.Status == New || p.Status == Failed)).ToList();
        }

        public bool IsUniqueName(string name)
        {
            return Context.Jobs.Any(p => p.Name.ToLower() == name.ToLower());
        }

        public void Update(Job job)
        {
            Context.Jobs.Update(job);
        }
    }
}
