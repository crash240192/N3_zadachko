using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3_orglist.Data
{
    public class OrgData
    {
        public string Code { get; set; }
        public string Display { get; set; }
        public string Version { get; set; }
        public OrgContains[] Contains { get; set; }
    }
}
