using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetTweet.Core;

namespace TweetTweet.Models
{
    internal class Post : Entity
    {
        public string PostTitle { get; set; }
        public string PostBody { get; set; }


        public int UserId { get; set; }
        public User User { get; set; }
    }
}
