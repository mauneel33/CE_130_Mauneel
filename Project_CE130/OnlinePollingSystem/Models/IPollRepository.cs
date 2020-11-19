using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePollingSystem.Models
{
    public interface IPollRepository
    {
        //Adding a poll by user
        Task Add(Poll poll);

        //Returning Polls in which user has not voted
        IEnumerable<Poll> GetAllPolls(string userid);

        //Vote Update after user voted
        Poll UpdateVote(int pollid, int optid, string userid);

        //Returning all Polls added by the User
        List<Poll> UserPolls(string userid);

        //Deleting a poll with pollid
        Task Delete(int pollid);

        //Returning a poll with pollid
        Poll GetPoll(int pollid);

        //Returning polls in which user has voted but user is not its author
        List<Poll> GetOtherPolls(string userid);

        //Delete all polls added by the user
        void DeletePolls(string userid);

        //Returning all users of system
        List<ApplicationUser> GetAllUsers();

        //Returning all polls of system
        List<Poll> GetEveryPoll();

        //Returning a user with userid
        ApplicationUser GetUser(string userid);

        //Delete a user with userid
        Task DeleteUser(string userid);
    }
}
