using Braveior.BuddyRewards.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Braveior.BuddyRewards.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HealthController : ControllerBase
    {

        public HealthController()
        {

        }

        [HttpGet]
        public InfoDTO GetInfo()
        {
            throw new Exception("error");
            return new InfoDTO { AppEnvironment = GetEnvironmentVariable("APPENVIRONMENT"), AppHost = GetEnvironmentVariable("APPHOST") };
        }

        private string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name.ToLower()) ?? Environment.GetEnvironmentVariable(name.ToUpper());
        }



    }
}
