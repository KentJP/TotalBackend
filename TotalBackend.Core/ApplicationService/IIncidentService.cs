using System;
using System.Collections.Generic;
using System.Text;
using TotalBackend.Core.Entity;

namespace TotalBackend.Core.ApplicationService
{
    public interface IIncidentService
    {
        Incident CreateIncident(Incident incident);

        Incident FindIncidentById(int id);
        List<Incident> GetAllIncidents();
        Incident UpdateIncident(Incident updatedIncident);
       
        Incident DeleteIncident(int id);


    }
}
