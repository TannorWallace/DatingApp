using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
           _context = context;
        }

        [Authorize]
        //Not Authorized
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "You Are Unsanctioned...";
        }

    
        //404 
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            //this thing does not exist so it will error.
            var thing = _context.Users.Find(-1);
            if(thing == null) return NotFound();
            //but it will never ok it.
            return Ok(thing);

        }


        //500
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.Users.Find(-2);

            var thingToReturn = thing.ToString();
            return thingToReturn;
        }

  
        //
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("Machine Spirit: Please restate your query...");
        }

    }
}