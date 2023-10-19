using System.Collections;
using Threads.Models;

namespace Threads.Pages
{
    public class ThreadsGenerator
    {
        public static IEnumerable CreateThreads()
        {
            return new[]
            {

                new AThread {
                    User = "Dima Slepiankou",
                    Message = "asdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasdasd",
                    IsVerified = true,
                    Likes = 10,
                    Image = "profile.png",
                    Replies=10,
                    TimeAgo="2 min"
                },
                new AThread {
                    User = "loh",
                    Message = "Some msg2",
                    IsVerified = true,
                    Likes = 11,
                    Replies=10,
                    TimeAgo="3 min",
                    Image = "profile.png"
                },
                new AThread {
                    User = "DVBC",
                    Message = "Some msg3",
                    IsVerified = false,
                    Likes = 12,
                    Replies=10,
                    TimeAgo="10 min",
                    Image = "profile.png"
                }
            };
        }
    }
}
