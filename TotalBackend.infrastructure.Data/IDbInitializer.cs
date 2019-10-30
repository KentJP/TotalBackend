using System;
using System.Collections.Generic;
using System.Text;

namespace TotalBackend.infrastructure.Data
{
    public interface IDbInitializer
    {
        void SeedDatabase(Context ctx);
    }
}
