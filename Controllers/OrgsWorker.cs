using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using N3_orglist.Data;
using Newtonsoft.Json;

namespace N3_orglist.Controllers
{
    public static class OrgsWorker
    {
        public static MainContainer Main { get; private set; }

        private static bool localDict = false;


        static OrgsWorker()
        {
            if (localDict)
            {
                try
                {
                    string content;
                    using (StreamReader sr = new StreamReader("d:\\Projects\\n3o.txt"))
                    {
                        content = sr.ReadToEnd();
                    }

                    if (content != null)
                    {
                        Main = JsonConvert.DeserializeObject<MainContainer>(content);
                    }
                }
                catch (Exception ex)
                { 
                }
            }
            else
            {
                try
                {
                    Main = OrgsDictDownloader.DownloadOrgsDict();
                }
                catch (Exception ex)
                {
                }
            }
        }


        public static OrganizationShort[] GetOrgsByName(string query, int? skip=null, int? take = null, string orderby = null)
        {
            try
            {
                if (query?.Length > 2)
                {
                    string[] searchStrings = query.Split(' ');

                    List<OrgData> orgs = new List<OrgData>();

                    if (searchStrings.Length > 0)
                    {
                        orgs = Main?.Parameter[0]?.Resource.Expansion.Contains.ToList().FindAll(org => org.Display.ToUpper().Contains(searchStrings[0]?.ToUpper()));
                    }

                    if (orgs != null)
                    {
                        if (searchStrings.Length > 1)
                        {
                            for (int i = 1; i < searchStrings.Length; i++)
                            {
                                orgs = orgs.FindAll(org => org.Display.ToUpper().Contains(searchStrings[i].ToUpper()));
                            }
                        }


                        List<OrganizationShort> shortOrgs = new List<OrganizationShort>();
                        foreach (OrgData curOrg in orgs)
                        {
                            shortOrgs.Add(new OrganizationShort(curOrg));
                        }

                        if (orderby != null)
                        {
                            Comparison<OrganizationShort> orgsComparison = ShortOrgsComparator.GetComparison(orderby);
                            if (orgsComparison != null)
                                shortOrgs.Sort(orgsComparison);
                        }

                        if (skip != null && take != null)
                        {
                            shortOrgs = shortOrgs.GetRange(skip.Value, take.Value);
                        }

                        return shortOrgs.ToArray();
                    }
                    else 
                        throw new Exception("Список организаций пуст");
                }
                else
                    throw new Exception("Некорректно указано название организации");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static OrganizationShort[] GetOrgsByGUID(string guid)
        {
            try
            {
                List<OrgData> orgs = new List<OrgData>();
                orgs = Main?.Parameter[0]?.Resource.Expansion.Contains.ToList().FindAll(org => org.Code.ToUpper().Equals(guid?.ToUpper()));

                List<OrganizationShort> shortOrgs = new List<OrganizationShort>();
                if (orgs != null)
                {
                    foreach (OrgData curOrg in orgs)
                    {
                        shortOrgs.Add(new OrganizationShort(curOrg));
                    }

                    return shortOrgs.ToArray();
                }
                else
                    throw new Exception("Список организаций пуст");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
