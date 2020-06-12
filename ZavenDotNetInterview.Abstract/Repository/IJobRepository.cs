using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavenDotNetInterview.App.Models;

namespace ZavenDotNetInterview.Abstract
{
   public interface IJobRepository : IRepository<Job>
   {
      List<Job> GetJobToProcess();
      bool IsUniqueName(string name);
      void Update(Job job);
   }
}
