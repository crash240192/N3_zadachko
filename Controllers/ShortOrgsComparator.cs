using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N3_orglist.Data;

namespace N3_orglist.Controllers
{

    public enum OrgSortType
    { 
        Name,
        NameRev
    }

    public static class ShortOrgsComparator
    {

        public static Comparison<OrganizationShort> GetComparison(OrgSortType sortType)
        {
            switch (sortType)
            {
                case OrgSortType.Name: return CompareByName;
                case OrgSortType.NameRev: return CompareByNameRev;
            }
            return null;
        }


        public static Comparison<OrganizationShort> GetComparison(string orderBy)
        {
            switch (orderBy.ToUpper())
            {
                case "NAME": return GetComparison(OrgSortType.Name);
                case "NAMEREV": return GetComparison(OrgSortType.NameRev);
            }
            return null;
        }



        public static int CompareByName(OrganizationShort x, OrganizationShort y)
        {
            if (x == null || y == null)
                return 0;
            if (x.Name == null || y.Name== null)
                return 0;
            return x.Name.CompareTo(y.Name);
        }

        public static int CompareByNameRev(OrganizationShort x, OrganizationShort y)
        {
            if (x == null || y == null)
                return 0;
            if (x.Name == null || y.Name == null)
                return 0;
            return y.Name.CompareTo(x.Name);
        }

    }
}
