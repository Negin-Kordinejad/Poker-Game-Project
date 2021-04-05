using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PokerDomainModel.Contract.ContractValues;

namespace PokerDomainModel.Model
{
    public class Hand
    {
        private List<Card> _handCards;
        private HandValue _handValue;

        public Hand()
        {
            _handCards = new List<Card>();
        }
        public Hand(List<Card> handCards) : this()
        {
            _handCards.AddRange(handCards);
        }
        public HandValue HandValues
        {
            get { return _handValue; }
            set { _handValue = value; }
        }
        public List<Card> GetHand
        {
            get { return _handCards; }
        }

    }
}
