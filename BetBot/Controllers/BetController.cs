using BetBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BetBot.Controllers
{
    public class BetController : ApiController
    {
        private static UserInfo _userInfo;

        [Route("api/bets")]
        [HttpPost]
        public string StartBets()
        {
            _userInfo = new UserInfo();

            return "Started";
        }

        // GET api/values
        [Route("api/bets")]
        public IEnumerable<Sport> GetBets()
        {
            return new List<Sport>
            {
                new Sport("Football") { Synonyms = new List<string> { "Football", "LaLiga", "Premier" } },
                new Sport("Basket") {Synonyms = new List<string> { "Basket", "Basketball", "ACB", "NBA" } },
                new Sport("MotoGP") { Synonyms = new List<string> { "Moto", "MotoGP", "Motos", "Motor", "Motorbikes"} }
            };
        }

        [Route("api/bets/events/{sportName}")]
        public IEnumerable<SportEvent> GetEvents(string sportName)
        {
            switch (sportName)
            {
                case ("Football"):
                    return BuildFootballSportEvents();
                case ("Basket"):
                    return BuildBasketSportEvents();
                case ("MotoGP"):
                    return BuildMotoGPSportEvents();
                default:
                    return new List<SportEvent>();
            }
        }

        [Route("api/bets/{eventId}")]
        public IEnumerable<string> GetEventBets(string eventId)
        {
            switch (eventId)
            {
                case ("1"):
                case ("2"):
                case ("3"):
                case ("4"):
                    return new List<string>
                    {
                        "Score", "Winner"
                    };
                case ("5"):
                case ("6"):
                    return new List<string>
                    {
                        "Winner"
                    };
                default:
                    return new List<string>();
            }
        }

        [Route("api/bets")]
        [HttpPut]
        public string ConfirmBet([FromBody]Bet value)
        {
            if (_userInfo == null)
            {
                _userInfo = new UserInfo();
            }

            _userInfo.Bets.Add(new Bet
            {
                EventId = value.EventId,
                BetResult = value.BetResult,
                BetType = value.BetType,
                EventName = value.EventName
            });

            return "OK";
        }

        [Route("api/me/bets")]
        public List<Bet> GetMyBets()
        {
            return _userInfo.Bets;
        }


        private List<SportEvent> BuildFootballSportEvents()
        {
            return new List<SportEvent>
                    {
                        new SportEvent
                        {
                            Id = "1",
                            Sport = new Sport("Football"),
                            Team1 = "Real Madrid",
                            Team2 = "Real Betis",
                            EventName = "Real Madrid Real Betis",
                            Synonyms = new List<string> { "Real Madrid Real Betis", "Madrid Betis", "Real Madrid", "Real Betis", "Betis Madrid", "MadridBetis", "BetisMadrid", "Madrid Real Betis", "Real Madrid Betis" }
                        },
                        new SportEvent
                        {
                            Id = "2",
                            Sport = new Sport("Football"),
                            Team1 = "Barcelona",
                            Team2 = "Valencia",
                            EventName = "Barcelona Valencia",
                            Synonyms = new List<string> { "Barcelona Valencia", "Barsa Valencia", "Valencia Barsa", "Valencia", "Barsa" }
                        },
                    };
        }

        private List<SportEvent> BuildBasketSportEvents()
        {
            return new List<SportEvent>
                    {
                        new SportEvent
                        {
                            Id = "3",
                            Sport = new Sport("Basket"),
                            Team1 = "Real Madrid",
                            Team2 = "Real Betis",
                            EventName = "Real Madrid Real Betis",
                            Synonyms = new List<string> { "Real Madrid Real Betis", "Madrid Betis", "Real Madrid", "Real Betis", "Betis Madrid", "MadridBetis", "BetisMadrid", "Madrid Real Betis", "Real Madrid Betis" }
                        },
                        new SportEvent
                        {
                            Id = "4",
                            Sport = new Sport("Basket"),
                            Team1 = "Barcelona",
                            Team2 = "Valencia",
                            EventName = "Barcelona Valencia Basket",
                            Synonyms = new List<string> { "Barcelona Valencia", "Barsa Valencia", "Valencia Barsa", "Valencia", "Barsa" }
                        },
                    };
        }

        private List<SportEvent> BuildMotoGPSportEvents()
        {
            return new List<SportEvent>
                    {
                        new SportEvent
                        {
                            Id = "5",
                            Sport = new Sport("MotoGP"),
                            EventName = "Australian GP",
                            Synonyms = new List<string> {"Australia", "Australian GP", "AustralianGP", "Australia Race" }
                            
                        },
                        new SportEvent
                        {
                            Id = "6",
                            Sport = new Sport("MotoGP"),
                            EventName = "World championship",
                            Synonyms = new List<string> {"World champion", "Champion" }
                        },
                    };
        }
    }
}
