using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aula.WebAPI.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected string GetSearchParameters(string name)
        {
            return HttpContext.Request.Query.ContainsKey(name) ? HttpContext.Request.Query[name].ToString() : "";
        }

        protected int GetSearchIntParameters(string name)
        {
            return int.Parse(HttpContext.Request.Query.ContainsKey(name) ? HttpContext.Request.Query[name].ToString() : "0");
        }
    }
}
