using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TotalBackend.Core.ApplicationService;
using TotalBackend.Core.Entity;

namespace TotalBackend.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private IIncidentService _incidentService;

        public IncidentController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Incident>> Get()
        {
            try
            {
                return Ok(_incidentService.GetAllIncidents());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                return Ok(_incidentService.FindIncidentById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Incident> Post([FromBody] Incident incident)
        {
            try
            {
                return Ok(_incidentService.CreateIncident(incident));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace + "\n" + e.InnerException);
                return BadRequest(e.StackTrace + "\n" + e.InnerException);
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Incident> Put(int id, [FromBody] Incident incident)
        {
            try
            {
                incident.Id = id;
                return Ok(_incidentService.UpdateIncident(incident));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Incident> Delete(int id)
        {
            try
            {
                return Ok(_incidentService.DeleteIncident(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
