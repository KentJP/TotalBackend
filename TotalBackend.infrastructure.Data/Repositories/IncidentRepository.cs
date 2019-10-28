using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TotalBackend.Core.DomainService;
using TotalBackend.Core.Entity;

namespace TotalBackend.infrastructure.Data.Repositories
{
    class IncidentRepository : IIncidentRepository
    {
        readonly Context _ctx;
        public IncidentRepository(Context ctx)
        {
            _ctx = ctx;
        }
        public Incident Create(Incident incident)
        {
            var inc = _ctx.Incident.Add(incident).Entity;
            _ctx.SaveChanges();
            return inc;
        }

        public Incident Delete(int id)
        {
            var deletedIncident = _ctx.Remove(new Incident { Id = id }).Entity;
            _ctx.SaveChanges();
            return deletedIncident;
        }

        public IEnumerable<Incident> getAllIncidents()
        {
            return _ctx.Incident;
        }

        public Incident ReadById(int id)
        {
            return _ctx.Incident.FirstOrDefault(i => i.Id == id);
        }

        public Incident Update(Incident updatedIncident)
        {
            _ctx.Attach(updatedIncident).State = EntityState.Modified;
            _ctx.SaveChanges();
             return updatedIncident;
        }
    }
}
