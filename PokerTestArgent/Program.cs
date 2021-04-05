using PokerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tournament;

namespace PokerTestArgent
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// please Uncomment the part for running
        /// </summary>
        static void Main(string[] args)
        {
            //Console Game 
            IPokerHandSorter TC = new PokerHandSorterConsole();
            TC.StartTournament();

            // Reading Hans from the text file
            //IPokerHandSorter TF = new PokerHandSorterFile();
            //TF.StartTournament();
        }
    }
}
