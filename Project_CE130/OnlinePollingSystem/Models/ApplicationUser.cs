using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePollingSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public int Nop { get; set; } = 0;
        public long Nov { get; set; } = 0;

        public ICollection<Poll> Polls { get; set; }
        public IList<UserActivity> UserActivities { get; set; }
    }
}
