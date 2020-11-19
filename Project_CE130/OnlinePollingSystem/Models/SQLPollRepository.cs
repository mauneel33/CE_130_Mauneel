using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlinePollingSystem.Data;
using OnlinePollingSystem.Models;

namespace OnlinePollingSystem.Models
{
    public class SQLPollRepository : IPollRepository
    {
        public SQLPollRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public ApplicationDbContext Context { get; }

        //Adding a poll by user
        public async Task Add(Poll poll)
        {
            ApplicationUser au = Context.ApplicationUsers.Single(u => u.Id == poll.UserId);
            au.Nop += 1;
            Context.ApplicationUsers.Update(au);
            Context.Polls.Add(poll);
            await Context.SaveChangesAsync();
        }

        //Returning Polls in which user has not voted
        public IEnumerable<Poll> GetAllPolls(string userid)
        {
            List<UserActivity> ua = Context.UserActivities.Where(ua=>ua.UserId==userid).ToList();
            List<int> userpolls = new List<int>();
            foreach(var u in ua)
            {
                userpolls.Add(u.PollId);
            }

            List<Poll> p = Context.Polls.ToList();
            foreach(var i in p.ToList())
            {
                if(userpolls.Contains(i.PollId))
                {
                    p.Remove(i);
                }
            }
            return p;
        }

        //Vote Update after user voted
        public Poll UpdateVote(int pollid, int optid, string voterid)
        {
            Poll p = Context.Polls.Single(pl => pl.PollId == pollid);

            string[] options = p.Opt.Split(",");
            string sopt = options[optid];
            UserActivity ua = new UserActivity
            {
                PollId = pollid,
                UserId = voterid,
                Option = sopt
            };
            //Update User Activity
            Context.UserActivities.Add(ua);

            string[] votes = p.Votes.Split(",");
            long optvote = Int64.Parse(votes[optid]);
            optvote += 1;
            votes[optid] = optvote.ToString();
            int i = 0;
            p.Votes = "";
            for(i=0; i<votes.Length-1; i++)
            {
                p.Votes += votes[i] + ",";
            }
            p.Votes += votes[i];
            //Update Votes in Poll
            Context.Polls.Update(p);

            string auser = p.UserId;
            ApplicationUser au = Context.ApplicationUsers.Single(u => u.Id == auser);
            au.Nov += 1;
            //Update Votes for Application User
            Context.ApplicationUsers.Update(au);

            Context.SaveChanges();

            return p;
        }

        //Returning all Polls added by the User
        public List<Poll> UserPolls(string userid)
        {
            List<Poll> p = Context.Polls.Where(pl=>pl.UserId == userid).ToList();   
            return p;
        }

        //Deleting a poll with pollid
        public async Task Delete(int pollid)
        {
            Poll p = Context.Polls.Single(i=>i.PollId == pollid);
            Context.Polls.Remove(p);
            await Context.SaveChangesAsync();
        }

        //Returning a poll with pollid
        public Poll GetPoll(int pollid)
        {
            Poll p = Context.Polls.Single(i => i.PollId == pollid);
            return p;
        }

        //Returning polls in which user has voted but user is not its author
        public List<Poll> GetOtherPolls(string userid)
        {
            List<UserActivity> ua = Context.UserActivities.Where(ua => ua.UserId == userid).ToList();
            List<int> userpolls = new List<int>();
            foreach (var u in ua)
            {
                userpolls.Add(u.PollId);
            }

            List<Poll> p = Context.Polls.ToList();
            foreach (var i in p.ToList())
            {
                if (!userpolls.Contains(i.PollId))
                {
                    p.Remove(i);
                }
            }
            foreach(var i in p.ToList())
            {
                if(i.UserId.Equals(userid))
                {
                    p.Remove(i);
                }
            }
            return p;
        }

        //Delete all polls added by the user
        public void DeletePolls(string userid)
        {
            List<Poll> p = Context.Polls.Where(p=>p.UserId == userid).ToList();
            foreach(var i in p.ToList())
            {
                Context.Polls.Remove(i);
            }
            Context.SaveChanges();
        }

        //Returning all users of system
        public List<ApplicationUser> GetAllUsers()
        {
            return Context.ApplicationUsers.ToList();
        }

        //Returning all polls of system
        public List<Poll> GetEveryPoll()
        {
            return Context.Polls.ToList();
        }

        //Returning a user with userid
        public ApplicationUser GetUser(string userid)
        {
            return Context.ApplicationUsers.Single(au=>au.Id == userid);
        }

        //Delete a user with userid
        public async Task DeleteUser(string userid)
        {
            ApplicationUser au = Context.ApplicationUsers.Single(au=>au.Id == userid);
            Context.ApplicationUsers.Remove(au);
            await Context.SaveChangesAsync();
        }
    }
}
