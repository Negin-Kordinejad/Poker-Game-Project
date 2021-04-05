using PokerDomain;
using PokerDomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Model;
using System.IO;

namespace Tournament
{
    public class PokerHandSorterConsole : IPokerHandSorter
    {
         
        IDealCarts _dealcarts;
        TournamentModel _tournament;
        ILogger _logger;
        public PokerHandSorterConsole()
        {
            //Todo:Add DI 
            _dealcarts = new DealCarts();
        }
        public void StartTournament()
        {

            List<Player> players = new List<Player>
            {
                new Player { Name = "Player1", WinerHands = 0 },
                new Player { Name = "Player2", WinerHands = 0 }
            };

            _tournament = new TournamentModel(players);

            //=============== Console Game ================

            string hand = "";
            Tuple<string, int> TResult;
            try
            {
                do
                {
                    Console.WriteLine("Play:");

                    hand = Console.ReadLine();

                  //To Do:check the format in user inerface teir. 
                    if (hand.Length == 1 && hand.ToUpper().Contains("X"))
                        break;

                    TResult = _dealcarts.Deal("Player1", "Player2", hand);

                    _tournament.Players.Find(p =>
                    p.Name == TResult.Item1).WinerHands = TResult.Item2;

                } while (1 == 1);

                //Need to change
                if (hand.Length == 19)
                {
                    Console.WriteLine(_tournament.ShowResult());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Please check the hand format.");
                _logger.LogException(e, "");
            }
            Console.ReadKey();
        }

    

    }
}
