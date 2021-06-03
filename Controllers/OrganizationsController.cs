using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N3_orglist.Data;
using System.IO;
using Newtonsoft.Json;

namespace N3_orglist.Controllers
{
    [ApiController]
    [Route("api")]
    public class OrganizationsController
    {

        public OrganizationsController()
        {
        }

        [HttpGet(Name = "Get by name")]
        [Route("organization")]
        public object GetOrganizations(string search, int? skip=null, int? take=null, string orderby = null)
        {
            try
            {
                Response response = new Response()
                {
                    Result = OrgsWorker.GetOrgsByName(search, skip, take, orderby),
                    Success = true
                };

                return response.Result;
            }
            catch (Exception ex)
            {
                return new Response()
                {
                    Success = false,
                    ErrorText = ex.Message
                };
            }
        }


        [HttpGet(Name = "Get by guid")]
        [Route("organization/{guide}")]
        public object GetOrganizationsByGUID(string guide)
        {
            try
            {
                Response response = new Response()
                {
                    Result = OrgsWorker.GetOrgsByGUID(guide),
                    Success = true
                };

                return response.Result;
            }
            catch ( Exception ex)
            {
                return new Response()
                {
                    Success = false,
                    ErrorText = ex.Message
                };
            }
        }
    }

    
}
