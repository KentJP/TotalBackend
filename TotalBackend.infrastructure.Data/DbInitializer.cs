using System;
using System.Collections.Generic;
using System.Text;
using TotalBackend.Core.Entity;

namespace TotalBackend.infrastructure.Data
{
    class DbInitializer : IDbInitializer
    {
        public void SeedDatabase(Context ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var Incident1 = ctx.Incident.Add(new Incident()
            {
                Id = 1,
                EntryDate = new DateTime(2019, 6, 11),
                EntryByUser = "Hej",
                Platform = "Hej",
                Type = "hej"

            }).Entity;
            var Incident2 = ctx.Incident.Add(new Incident()
            {
                Id = 2,
                EntryDate = new DateTime(2019, 6, 11),
                EntryByUser = "Hej",
                Platform = "Hej",
                Type = "hej"

            }).Entity;



        }
    }
}
