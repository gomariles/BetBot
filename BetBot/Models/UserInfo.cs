using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetBot.Models
{
    public class UserInfo
    {
        public UserInfo()
        {
            Bets = new List<Bet>();
        }
        public List<Bet> Bets { get; set; }
    }
}