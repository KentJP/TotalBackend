using System;
using System.Collections.Generic;
using System.Text;
using TotalBackend.Core.Entity;

namespace TotalBackend.Core.DomainService
{
    public interface IIncidentRepository
    {
        IEnumerable<Incident> getAllIncidents();
        Incident Create(Incident incident);
        Incident ReadById(int id);
        Incident Delete(int id);
        Incident Update(Incident updatedIncident);
    }
}
