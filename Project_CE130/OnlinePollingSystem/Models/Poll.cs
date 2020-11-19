using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePollingSystem.Models
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Que { get; set; }
        public string Opt { get; set; }
        public string Votes { get; set; }
        public DateTime? Date { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public IList<UserActivity> UserActivities { get; set; }
    }
}
