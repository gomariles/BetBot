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
        public void StartBets()
        {
            _userInfo = new UserInfo();
        }

        // GET api/values
        [Route("api/bets")]
        public IEnumerable<Sport> GetBets()
        {
            return new List<Sport>
            {
                new Sport("Football"),
                new Sport("Basket"),
                new Sport("MotoGP")
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
        public IEnumerable<BetType> GetBets(string eventId)
        {
            switch (eventId)
            {
                case ("1"):
                case ("2"):
                case ("3"):
                case ("4"):
                    return new List<BetType>
                    {
                        new BetType
                        {
                            Name = "Score"
                        },
                        new BetType
                        {
                            Name = "Winner"
                        }
                    };
                case ("5"):
                case ("6"):
                    return new List<BetType>
                    {
                        new BetType
                        {
                            Name = "Winner"
                        }
                    };
                default:
                    return new List<BetType>();
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
                BetType = value.BetType
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
                            EventName = "LaLiga Match"
                        },
                        new SportEvent
                        {
                            Id = "2",
                            Sport = new Sport("Football"),
                            Team1 = "Barcelona",
                            Team2 = "Valencia",
                            EventName = "LaLiga Match"
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
                            EventName = "Liga Endesa Match"
                        },
                        new SportEvent
                        {
                            Id = "4",
                            Sport = new Sport("Basket"),
                            Team1 = "Barcelona",
                            Team2 = "Valencia",
                            EventName = "Liga Endesa Match"
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
                            EventName = "Australian GP"
                        },
                        new SportEvent
                        {
                            Id = "6",
                            Sport = new Sport("MotoGP"),
                            EventName = "World championship"
                        },
                    };
        }
    }
}
