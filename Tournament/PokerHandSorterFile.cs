using PokerDomain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament.Model;



namespace Tournament
{
    public class PokerHandSorterFile : IPokerHandSorter
    {
        DealCarts _dealcarts;
        TournamentModel _tournament;
        ILogger _logger;
        public PokerHandSorterFile()
        {
            _dealcarts = new DealCarts();
        }
        public void StartTournament()
        {
            Console.WriteLine("-----Start Tournament------");

            List<Player> players = new List<Player>
            {
                new Player { Name = "Player1", WinerHands = 0 },
                new Player { Name = "Player2", WinerHands = 0 }
            };

            _tournament = new TournamentModel(players);

            try
            {
                IEnumerable<string> handList = File.ReadLines(@"C:\Argent\poker-hands.txt");

                handList.ToList().ForEach(h =>
                {
                    Tuple<string, int> TResult = _dealcarts.Deal("Player1", "Player2", h);

                    _tournament.Players.Find(p =>
                    p.Name == TResult.Item1).WinerHands = TResult.Item2;

                });

                Console.WriteLine(_tournament.ShowResult());
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("problem in input file.");
                _logger.LogException(e, "");
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
