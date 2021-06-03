using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3_orglist.Data
{
    public class Resource
    {
        public string ID { get; set; }
        public string URL { get; set; }
        public Meta Meta { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public Contact[] Contact { get; set; }
        public string Version { get; set; }
        public Expansion Expansion { get; set; }
        public string Publisher { get; set; }
        public Context UseContext { get; set; }
        public string Experimental { get; set; }
        public string REsourceType { get; set; }
    }

    
}
