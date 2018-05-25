using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace dubyawebapi.Controllers
{
    [Route("x/[controller]")]
    public class IgnatzController : Controller
    {
       
        // GET api/Ignatz
        [HttpGet]
        public JsonResult Get()
        {
            return Json(MyCollection);//see below
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(string id)
        {
            var rslt = Json(new{ Henry = 3, Margaret = 9});
            return rslt;//.ToString() + " value is " + id;
        }

        // POST api/values
        [HttpPost]
        public JsonResult Post([FromBody]object value)
        {
            Dictionary<string,object> xdict = JsonConvert.DeserializeObject<Dictionary<string, object>>(value.ToString());
            var nxtid = NextId();
            MyCollection.Add((new Dictionary<String,object>()
                {
                    {"id", 88},
                    {"name", "me"}, 
                    {"isComplete","true"}
                }));  
            var rslt = Json(new{ Henry = xdict["name"], Margaret = xdict["isComplete"]});
            return rslt;//.ToString() + " value is " + id;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public JsonResult Put(string id, [FromBody]object value)
        {
            var rslt = Json(new{ Henry = "putUpdate"+id, Margaret = value});
            return rslt;//.ToString() + " value is " + id;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
        }
         private List<Dictionary<String,object>> MyCollection{ get; set;} = new List<Dictionary<String,object>>()
         {
                (new Dictionary<String,object>()
                {
                    {"id", 1},
                    {"name", "you"}, 
                    {"isComplete","true"}
                }),
                (new Dictionary<String,object>()
                {
                    {"id", 2},
                    {"name", "me"}, 
                    {"isComplete","true"}
                })
        };
        private int NextId()
        {
            int rslt = 99;
            var rows = MyCollection.Select(row => row).ToArray();
           
            return rslt;

        }
    }
}