using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ZavenDotNetInterview.Abstract.Logic;
using ZavenDotNetInterview.Common.ViewModels;
using ZavenDotNetInterview.Logic;

namespace ZavenDotNetInterview.App.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobLogic _logic;
        public JobsController(IJobLogic logic)
        {
            _logic = logic;
        }

        // GET: Tasks
        [HttpGet]
        public ActionResult Index()
        {
            return View(_logic.GetAll());
        }
        
        // GET: Tasks/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public ActionResult Create(JobViewModel vm)
        {
            if (!string.IsNullOrWhiteSpace(vm.Name) && _logic.IsUniqueName(vm.Name))
            {
                ModelState.AddModelError("Name","Name is not unique");
            }
            if (!ModelState.IsValid)
                return View("Create", vm);
            
            Guid result = _logic.Add(vm);

          return RedirectToAction("Details", new {jobId = result});
        }

        public ActionResult Details(Guid jobId)
        {
            return View(_logic.Get(jobId));
        }

        [HttpPost]
        public async Task<bool> Process()
        {
            return await _logic.ProcessJobs();
        }
    }
}
