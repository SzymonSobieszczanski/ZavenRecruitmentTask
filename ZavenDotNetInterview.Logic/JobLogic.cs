using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ZavenDotNetInterview.Abstract.Logic;
using ZavenDotNetInterview.App.Models;
using ZavenDotNetInterview.Common.Enums;
using ZavenDotNetInterview.Common.ViewModels;
using ZavenDotNetInterview.Data;

namespace ZavenDotNetInterview.Logic
{
    public class JobLogic : IJobLogic
    {
        //I should use Automapper or all mappings from vm to db model put in different static class. 
        private ILogLogic logLogic;
        public JobLogic(ILogLogic LogLogic)
        {
            logLogic = LogLogic;
        }
        public Guid Add(JobViewModel entity)
        {
            Guid id;
            var temp = new Job();
            temp.Name = entity.Name;
            temp.DoAfter = entity.DoAfter;
            temp.Status = entity.Status;
            temp.CreatedAt = DateTime.Now;;
            using (var _context = new UnitOfWork(new ApplicationDbContext()))
            {
                id = _context.Jobs.Add(temp);
            }    
            logLogic.CreatingLog(id);
            return id;
        }
        public JobViewModel Get(Guid id)
        { 
            var temp = new JobViewModel();
                var temp1 = new Job();
                using (var context = new UnitOfWork(new ApplicationDbContext()))
                {
                    temp1 = context.Jobs.Get(id);
                }

                if (temp1 != null)
                {
                    temp.Name = temp1.Name;
                    temp.DoAfter = temp1.DoAfter;
                    temp.Status = temp1.Status;
                    temp.Id = temp1.Id;
                    foreach (var item in temp1.Logs)
                    {
                        var logVm = new LogViewModel
                        {
                            Description = item.Description,
                            CreatedAt = item.CreatedAt
                        };
                        temp.Logs.Add(logVm);
                    }
                }
                return temp;
        }

        public IEnumerable<JobViewModel> GetAll()
        {
            IEnumerable<Job> result;
            using (var _context = new UnitOfWork(new ApplicationDbContext()))
            {
                 result = _context.Jobs.GetAll();
            }
            List<JobViewModel> test = new List<JobViewModel>();
            foreach (var item in result)
            {
                var temp1 = new JobViewModel
                {
                    Id = item.Id,
                    DoAfter = item.DoAfter,
                    Name = item.Name,
                    Status = item.Status,
                    CreatedAt = item.CreatedAt
                };
                test.Add(temp1);

            }

            return test;
        }

        public bool IsUniqueName(string name)
        {
            using (var _context = new UnitOfWork(new ApplicationDbContext()))
            {
                return _context.Jobs.IsUniqueName(name);
            }
        }

        public async Task<bool> ProcessJobs()
        {
            List<Job> jobsToProcess;
            List<JobProcessingViewModel> vm = new List<JobProcessingViewModel>();
            List<Task> currentTask = new List<Task>();
            using (var _context = new UnitOfWork(new ApplicationDbContext()))
            {
                jobsToProcess = _context.Jobs.GetJobToProcess();
                jobsToProcess.ForEach(job =>
                {
                    job.Status = JobStatus.InProgress;
                    _context.Logs.Add(new Log
                    {
                        CreatedAt = DateTime.Now,
                        JobId = job.Id,
                        Description = $"Status updated. New status: {job.Status}"
                    });
                });
                _context.SaveChanges();
            }

            foreach (var currentJob in jobsToProcess)
            {
                    
                var task = new Task(async () =>
                {
                    using (var _context = new UnitOfWork(new ApplicationDbContext()))
                    {
                        currentJob.LastUpdatedAt = DateTime.Now;
                        bool result = await this.ProcessJob(currentJob).ConfigureAwait(false);
                        if (result)
                        {
                            currentJob.Status = JobStatus.Done;
                        }
                        else
                        {
                            currentJob.Status = JobStatus.Failed;
                            currentJob.FailedCount = +1;
                            if (currentJob.FailedCount == 5)
                                currentJob.Status = JobStatus.Closed;
                        }

                        await _context.Logs.AddAsync(new Log
                        {
                            CreatedAt = DateTime.Now,
                            JobId = currentJob.Id,
                            Description = $"Status updated. New status: {currentJob.Status}"
                        });
                        _context.Jobs.Update(currentJob);
                        await _context.SaveChangesAsync();
                    }
                });
                currentTask.Add(task);
                task.Start();

            }
              
            await Task.WhenAll(currentTask.ToArray());
            
            return true;
        }

        private async Task<bool> ProcessJob(Job job)
        {
            Random rand = new Random();
            if (rand.Next(10) < 5)
            {
                await Task.Delay(2000);
                return false;
            }
            else
            {
                await Task.Delay(1000);
                return true;
            }
        }
    }
}
