using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Revolutionary.Areas.Identity.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Revolutionary.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CredentialsController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new { valid = true });
        }
    }
}
