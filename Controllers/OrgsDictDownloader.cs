using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using N3_orglist.Data;
using N3_orglist.Data.GetDictRequest;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace N3_orglist.Controllers
{
    public static class OrgsDictDownloader
    {
        public static string URL = "http://r78-rc.zdrav.netrika.ru/nsi/fhir/term/ValueSet/$expand?_format=json";

        public static MainContainer DownloadOrgsDict()
        {
            try
            {
                JSONCommunicator json = new JSONCommunicator();
                OrgsPostRequestBody orgsRequest = new OrgsPostRequestBody();
             
                var result = json.POST(URL, orgsRequest);
                
                MainContainer container = JsonConvert.DeserializeObject<MainContainer>(result);
                return container;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
