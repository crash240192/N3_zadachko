using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3_orglist.Data
{

    public class Expansion
    { 
        public OrgData[] Contains { get; set; }
        public ContainerParams[] Parameter { get; set; }
        public string TimeStamp { get; set; }
    }
}
