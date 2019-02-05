using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceHubApi.Data_Access;

namespace ServiceHubApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceEventController : ControllerBase
    {
        private ServiceEventContext _context;

        private IRetentionPolicyMatcher _retentionPolicyMatcher;

        public ServiceEventController(ServiceEventContext context, IRetentionPolicyMatcher retentionPolicyMatcher)
        {
            _context = context;
           _retentionPolicyMatcher = retentionPolicyMatcher;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<ServiceEvent>> Get()
        {
           var serviceEvents = _context.ServiceEvents.Include(se => se.RetentionPolicy).ToList();
           return serviceEvents;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetServiceEvent")]
        public ActionResult<ServiceEvent> Get(long id)
        {
            var serviceEvent =  _context.ServiceEvents.Find(id);
            if(serviceEvent == null) 
            {
                return NotFound();
            }
            return serviceEvent;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] ServiceEvent serviceEvent)
        {

            // assign a retention Policy to this serviceEvent

            var allPolicies = _context.RetentionPolicies.ToList();
            if (allPolicies?.Count > 0)
            {
                 serviceEvent.RetentionPolicy = _retentionPolicyMatcher.Match(serviceEvent, allPolicies);
            }

            serviceEvent.CreateDate = DateTime.UtcNow;
            _context.ServiceEvents.Add(serviceEvent);
            _context.SaveChanges();

            return CreatedAtRoute("GetServiceEvent", new {id = serviceEvent.Id}, serviceEvent);
        }

        //PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ServiceEvent serviceEvent)
        {
            if (id != serviceEvent.Id)
            {
                return BadRequest();
            }

            ServiceEvent foundServEvent = _context.ServiceEvents.Find(id);
            if (foundServEvent != null)
            {
                foundServEvent.IsRetained = serviceEvent.IsRetained;
               _context.SaveChanges();
            }           

           return Ok();
        }

        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
