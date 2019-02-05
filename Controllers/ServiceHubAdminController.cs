using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceHubApi.Data_Access;
using ServiceHubApi.Models;

namespace ServiceHubApi.Controllers {
    public class ServiceHubAdminController : Controller {

        private ServiceEventContext _dbContext = null;

        public ServiceHubAdminController (ServiceEventContext dbContext) {
            _dbContext = dbContext;
        }

        public IActionResult Index () {
            RetentionPolicy[] policies = _dbContext.RetentionPolicies.ToArray ();
            return View (policies);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public IActionResult Create () {
            RetentionPolicy rp = null;
            return View(rp);
        }

        [HttpPost]
        public IActionResult Create (RetentionPolicy retentionPolicy) {

            if (ModelState.IsValid) {
                _dbContext.RetentionPolicies.Add (retentionPolicy);
                _dbContext.SaveChanges();

                return RedirectToAction ("Index");
            } else {
                return View (retentionPolicy);
            }
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}