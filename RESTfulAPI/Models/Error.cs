using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulAPI.Models
{
    public class Error
    {
        public int StautsCode {get; set;}
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
        

    }
}
