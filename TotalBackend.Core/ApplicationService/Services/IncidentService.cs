using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public Incident DeleteIncident(int id)
        {
            throw new NotImplementedException();
        }

        public Incident FindIncidentById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Incident> GetAllIncidents()
        {
            throw new NotImplementedException();
        }

        public Incident UpdateIncident(Incident updatedIncident)
        {
            throw new NotImplementedException();
        }
    }
}
