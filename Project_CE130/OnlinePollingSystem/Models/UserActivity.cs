using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePollingSystem.Models
{
    public class UserActivity
    {
        public string Option { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int PollId { get; set; }
        public Poll Poll { get; set; }
    }
}
