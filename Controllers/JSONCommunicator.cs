using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3_orglist.Controllers
{

    static class JsonRequestSettings
    {
        public const string ContenetType = "application/json";
        public const string AcceptType = "application/json";
        public static RestRequest FillHeaders(RestRequest request)
        {
            request.AddHeader("Content-Type", ContenetType);
            request.AddHeader("Accept", AcceptType);            
            return request;
        }
    }


    public partial class JSONCommunicator
    {
        private RestClient Client;


        public JSONCommunicator()
        {
        }
        

        public string POST(string URL, Object Object)
        {
            try
            {
                RestRequest Request = new RestRequest(Method.POST);
                Client = new RestClient(URL);

                JsonRequestSettings.FillHeaders(Request);
                Request.AddJsonBody(Object);

                var response = Client.Post(Request);
                return response.IsSuccessful ? response.Content : throw new Exception(response?.Content ?? string.Empty, response?.ErrorException);
            }
            catch (Exception ex)
            {
                throw new Exception("Во время выполнения запроса <POST> к серверу возникло исключение " + ex);
            }
        }
    }
}
