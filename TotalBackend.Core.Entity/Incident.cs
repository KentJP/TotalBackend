using System;
using System.Collections.Generic;
using System.Text;

namespace TotalBackend.Core.Entity
{
    public class Incident
    {

        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string Type { get; set; }

        public string EntryByUser { get; set; }

        public string Platform { get; set; }
    }
}
