using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BetBot.Models
{
    public class Sport
    {
        public Sport(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public List<string> Synonyms { get; set; }
    }
}