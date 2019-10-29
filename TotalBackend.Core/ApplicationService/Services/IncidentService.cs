using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TotalBackend.Core.DomainService;
using TotalBackend.Core.Entity;

namespace TotalBackend.Core.ApplicationService.Services
{
    public class IncidentService : IIncidentService
    {
        private IIncidentRepository _incidentRepo;

        public IncidentService(IIncidentRepository incidentRepo)
        {
            _incidentRepo = incidentRepo;
        }
        public Incident CreateIncident(Incident incident)
        {
            return _incidentRepo.Create(incident);
        }

        public Incident DeleteIncident(int id)
        {
            return _incidentRepo.Delete(id);
        }

        public Incident FindIncidentById(int id)
        {
            return _incidentRepo.ReadById(id);
        }

        public List<Incident> GetAllIncidents()
        {
            return _incidentRepo.getAllIncidents().ToList();
        }

        public Incident UpdateIncident(Incident updatedIncident)
        {
            return _incidentRepo.Update(updatedIncident);
        }
    }
}
