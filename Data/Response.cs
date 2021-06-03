using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N3_orglist.Data
{
    public class Response
    {
        public object Result { get; set; }

        public bool Success { get; set; }
        public string ErrorText { get; set; }
    }
}
