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
        DealCarts _dealcarts;

        TournamentModel tournament;
        public PokerHandSorterConsole()
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

            //=============== Console Game ================

            string hand = "";
            do
            {
                Console.WriteLine("Play:");
                hand = Console.ReadLine();
                if (hand.Length == 1)
                    break;
                Tuple<string, int> TResult = _dealcarts.Deal("Player1", "Player2", hand);

                tournament.Players.Find(p =>
                p.Name == TResult.Item1).WinerHands = TResult.Item2;

            } while (1 == 1);
        
            Console.WriteLine(tournament.ShowResult());
            Console.ReadKey();
        }
      
    }
}
