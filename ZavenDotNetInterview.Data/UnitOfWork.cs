using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZavenDotNetInterview.Abstract;
using ZavenDotNetInterview.Data.Repository;

namespace ZavenDotNetInterview.Data
{
   public class UnitOfWork : IUnitOFWork
   {
       private readonly ApplicationDbContext _context;

       public UnitOfWork(ApplicationDbContext context)
       {
           _context = context;
           Jobs = new JobRepository(context);
           Logs = new LogRepository(context);
       }

       public IJobRepository Jobs { get; set; }
       public ILogRepository Logs { get; set; }

       public void SaveChanges()
       {
           _context.SaveChanges();
       }

       public async Task SaveChangesAsync()
       {
          await _context.SaveChangesAsync();
       }
       public void Dispose()
       {
            _context.SaveChanges();
            _context.Dispose();
       }
   }
}
