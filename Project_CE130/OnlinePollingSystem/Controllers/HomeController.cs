using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using OnlinePollingSystem.Models;
using OnlinePollingSystem.Data;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlinePollingSystem.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPollRepository _pollRepo;

        private readonly SignInManager<OnlinePollingSystem.Models.ApplicationUser> SignInManager;
        private readonly UserManager<OnlinePollingSystem.Models.ApplicationUser> UserManager;

        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, IPollRepository pollRepo, SignInManager<OnlinePollingSystem.Models.ApplicationUser> SignInManager, UserManager<OnlinePollingSystem.Models.ApplicationUser> UserManager, ApplicationDbContext context)
        {
            _logger = logger;
            _pollRepo = pollRepo;
            this.SignInManager = SignInManager;
            this.UserManager = UserManager;
            this.context = context;
        }
        
        public async Task<IActionResult> Index()
        {
            ApplicationUser au = context.ApplicationUsers.Single(au => au.Email == User.Identity.Name);
            var flag = await SignInManager.UserManager.IsInRoleAsync(au, "Admin");
            if(flag)
            {
                return LocalRedirect("/Admin/Index");
            }
            else
            {
                var model = _pollRepo.GetAllPolls(context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id);
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult AddPoll()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPoll([Bind("Que,Opt")] Poll poll)
        {
            if (ModelState.IsValid)
            {
                string userid = context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id;
                int nopt;
                string[] options = poll.Opt.Split(",");
                nopt = options.Length;
                string votes = "";
                for(int i=0; i<nopt-1; i++)
                {
                    votes += "0,";
                }
                votes += "0";
                poll.UserId = userid;
                poll.Votes = votes;
                poll.Date = DateTime.Now;
                await _pollRepo.Add(poll);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(AddPoll));
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public JsonResult UpdateVote(int pollid, int optid)
        {
            Poll p = _pollRepo.UpdateVote(pollid, optid, context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id);
            return Json(p);
        }

        public IActionResult MyPolls()
        {
            var model = _pollRepo.UserPolls(context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id);
            return View(model);
        }

        [HttpGet]
        [Route("Home/Delete/{id?}")]
        public IActionResult DeletePoll(int id)
        {
            Poll p = _pollRepo.GetPoll(id);
            if(p.UserId != context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id)
            {
                return NotFound();
            }
            if(p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost]
        [Route("Home/Delete/{id?}")]
        public async Task<IActionResult> DeleteConfirmed(int pollid)
        {
            Poll p = _pollRepo.GetPoll(pollid);
            if (p.UserId != context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id)
            {
                return NotFound();
            }
            await _pollRepo.Delete(p.PollId);

            return RedirectToAction("MyPolls");
        }

        public IActionResult MyActivity()
        {
            List<Poll> p = _pollRepo.GetOtherPolls(context.ApplicationUsers.Single(au => au.Email == User.Identity.Name).Id);
            return View(p);
        }
    }
}
