using PokerDomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tournament.Model
{
    public class Player
    {
        public string Name { get; set; }
        private int _WinerHands = 0;
        public int WinerHands
        {
            get
            {
                return _WinerHands;
            }
            set
            {
                _WinerHands = _WinerHands == 0 ? value : ++_WinerHands;
            }
        }
        public int GameResult
        {
            get
            {
                return WinerHands;
            }
        }
    }
}
