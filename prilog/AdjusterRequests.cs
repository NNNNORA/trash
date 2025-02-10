using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextLibrary.Entities
{
    public class AdjusterRequests
    {
        public required Mechanic Mechanic { get; set; }
        public required Request Request { get; set; }
    }
}
