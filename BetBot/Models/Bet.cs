using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetBot.Models
{
    public class Bet
    {
        public string EventName { get; set; }
        public string EventId { get; set; }
        public string BetType { get; set; }
        public string BetResult { get; set; }
    }
}