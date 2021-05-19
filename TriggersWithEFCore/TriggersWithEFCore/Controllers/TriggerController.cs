using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriggersWithEFCore.Models;
using TriggersWithEFCore.Persistence;

namespace TriggersWithEFCore.Controllers
{
    [ApiController, Route("api/v1/[controller]")]
    public class TriggerController : Controller
    {
        readonly TriggersEFCoreContext _triggersWithEFCoreContext;

        public TriggerController(TriggersEFCoreContext context)
        {
            _triggersWithEFCoreContext = context;
        }

        [HttpGet("thetriggers")]
        public IActionResult Index()
        {
            _triggersWithEFCoreContext.Users.Add(new User
            {
                Birthday = "12/25",
                Email = "trigger@thetriggers.net",
                Password = "sure",
                Username = "OKAY"
            });

            _triggersWithEFCoreContext.SaveChanges();

            return new ObjectResult("User Created") { StatusCode = StatusCodes.Status202Accepted };
        }

        [HttpGet("thebirthdays")]
        public IActionResult GetBirthdays()
        {
            return new OkObjectResult(_triggersWithEFCoreContext.UserBirthdays.ToArray());
        }

        [HttpGet("theusers")]
        public IActionResult GetUsers()
        {
            return new OkObjectResult(_triggersWithEFCoreContext.Users.ToArray());
        }
    }
}
