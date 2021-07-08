using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;

namespace Bookish.Controllers
{
    [Route("/[controller]/{action=Members}")]
    public class MembersController : Controller
    {

        public IActionResult Members()
        {
            return View(new MembersListViewModel());
        }

        public IActionResult Member()
        {
            var member = new MembersListViewModel
            {
                Members = new List<MemberViewModel>
                {
                    new MemberViewModel
                    {
                        FirstName = "Fab",
                        LastName = "Reader"
                    }
                }
            };
                           
            return View(member);
        }
    }


}
