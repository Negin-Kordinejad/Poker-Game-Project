using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PokerDomainModel.Contract.ContractValues;

namespace PokerDomainModel.Model
{
    public class Card
    {
        public Suit Suit { get; private set; }
        public CardValue Value { get; private set; }
        public Card()
        { }
        public Card(CardValue Value, Suit Suit)
        {
            this.Suit = Suit;
            this.Value = Value;
        }
        public int NValue()
        {
            return (int)Value;
        }

        public int NSuit()
        {
            return (int)Suit;
        }
    }
}
