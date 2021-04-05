using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Model
{
    public class TournamentModel
    {
        private List<Player> _players;
        public TournamentModel()
        {
            _players = new List<Player>();
        }
        public TournamentModel(List<Player> Players) : this()
        {
            _players = Players;
        }

        public List<Player> Players { get
            { return _players; } }
        public string ShowResult()
        {
            StringBuilder P = new StringBuilder();

            foreach (var p in _players)
            {
                P.Append(p.Name).Append(" : ").AppendLine(p.WinerHands.ToString());
            }
            return P.ToString();
        }
    }
}
