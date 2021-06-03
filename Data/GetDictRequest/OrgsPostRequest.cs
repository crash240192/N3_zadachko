using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace N3_orglist.Data.GetDictRequest
{
    public class OrgsPostRequestBody
    {
        //[JsonProperty("resourceType")]
        public string resourceType { get; set; }
        //[JsonProperty("parameter")]
        public RequestParameter[] parameter { get; set; }

        public OrgsPostRequestBody()
        {

            resourceType = "Parameters";
            parameter = new RequestParameter[]
            {
                new RequestParameter()
                {
                    name = "system",
                    valueString = "urn:oid:1.2.643.2.69.1.1.1.64"
                }
            };
        }
    }


    public class RequestParameter
    {
        //[JsonProperty("name")]
        public string name { get; set; }
        //[JsonProperty("valueString")]
        public string valueString { get; set; }
    }
}
