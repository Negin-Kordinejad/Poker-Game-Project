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

        TournamentModel tournament;
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

            tournament = new TournamentModel(players);


            //============ Games From File  ==============
            try
            {
                IEnumerable<string> handList = File.ReadLines(@"C:\Argent\poker-hands.txt");

                handList.ToList().ForEach(h =>
                {
                    Tuple<string, int> TResult = _dealcarts.Deal("Player1", "Player2", h);

                    tournament.Players.Find(p =>
                    p.Name == TResult.Item1).WinerHands = TResult.Item2;

                });
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("problem in input file.");
                Log(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Please check the hand format.");
                Log(e.Message);
            }
            Console.WriteLine(tournament.ShowResult());
            Console.ReadKey();
        }

        private void Log(string message)
        {
            throw new NotImplementedException();
        }
    }
}
