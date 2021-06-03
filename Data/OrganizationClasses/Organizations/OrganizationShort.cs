using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3_orglist.Data
{
    public class OrganizationShort
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public OrganizationShort()
        { 
        }

        public OrganizationShort(OrgData orgData)
        {
            ID = orgData.Code;
            Name = orgData.Display;
        }

    }
}
