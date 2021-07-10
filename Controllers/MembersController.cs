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

        [HttpGet]
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

        [HttpGet("/[controller]/{id}")]
        public IActionResult Member(int id)
        {
            var model = _memberService.GetMemberById(id);    
            return View(new MemberViewModel(model));
        }

        [HttpGet]
        public IActionResult AddMember()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMember(AddMemberViewModel addMemberViewModel)
        {
            _memberService.AddMember(addMemberViewModel);
            return RedirectToAction("Members");
        }
    }


}
