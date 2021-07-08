using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bookish.Models;
using Bookish.Services;

namespace Bookish.Controllers
{
    [Route("/[controller]/{action=Members}")]
    public class MembersController : Controller
    {
        private readonly IMemberService _memberService;

        public MembersController (IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Members()
        {
            var membersInDb = _memberService.GetMembers();
            var members = membersInDb.Select(member => new MemberViewModel(member)).ToList();
            var membersList = new MembersListViewModel
            {
                Members = members
            };
            return View(membersList);
        }

        public IActionResult Member()
        {
            var model = new MemberViewModel();
              
            return View(model);
        }
    }


}
