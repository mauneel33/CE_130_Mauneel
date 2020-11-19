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

namespace OnlinePollingSystem
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IPollRepository _pollRepo;

        private readonly SignInManager<OnlinePollingSystem.Models.ApplicationUser> SignInManager;
        private readonly UserManager<OnlinePollingSystem.Models.ApplicationUser> UserManager;

        private readonly ApplicationDbContext context;

        public AdminController(ILogger<AdminController> logger, IPollRepository pollRepo, SignInManager<OnlinePollingSystem.Models.ApplicationUser> SignInManager, UserManager<OnlinePollingSystem.Models.ApplicationUser> UserManager, ApplicationDbContext context)
        {
            _logger = logger;
            _pollRepo = pollRepo;
            this.SignInManager = SignInManager;
            this.UserManager = UserManager;
            this.context = context;
        }

        public IActionResult Index()
        {
            List<ApplicationUser> au = _pollRepo.GetAllUsers();
            return View(au);
        }

        public IActionResult PollDetails()
        {
            List<Poll> p = _pollRepo.GetEveryPoll();
            return View(p);
        }

        [HttpGet]
        [Route("Admin/DeletePoll/{id?}")]
        public IActionResult DeletePoll(int id)
        {
            Poll p = _pollRepo.GetPoll(id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost]
        [Route("Admin/DeletePoll/{id?}")]
        public async Task<IActionResult> DeleteConfirmed(int pollid)
        {
            Poll p = _pollRepo.GetPoll(pollid);
            await _pollRepo.Delete(p.PollId);

            return RedirectToAction("PollDetails");
        }

        [HttpGet]
        [Route("Admin/DeleteUser/{id?}")]
        public IActionResult DeleteUser(string id)
        {
            ApplicationUser au = context.ApplicationUsers.Single(au=>au.Id == id);
            if (au == null)
            {
                return NotFound();
            }
            return View(au);
        }

        [HttpPost]
        [Route("Admin/DeleteUser/{id?}")]
        public async Task<IActionResult> DeleteUserConfirmed(string id)
        {
            ApplicationUser au = _pollRepo.GetUser(id);
            _pollRepo.DeletePolls(id);
            await _pollRepo.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}
