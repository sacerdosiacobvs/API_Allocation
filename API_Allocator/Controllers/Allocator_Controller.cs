using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Xml;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;
using Newtonsoft.Json.Linq;

namespace API_Allocator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Allocator_Controller : ControllerBase
    {




        [HttpGet]
        public string Get(int units, int hours)
        {
            Allocator a = new Allocator();
            string new_york=a.Calcular("New York",units,hours);
            string india = a.Calcular("India", units, hours);
            string china = a.Calcular("China", units, hours);


            return new_york+india+china;
        }




    }
}
