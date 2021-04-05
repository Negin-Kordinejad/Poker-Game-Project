using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerDomainModel.Contract
{
    public class ContractValues
    {
        public enum Suit
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public enum CardValue
        {
            Two = 2, Three, Four, Five, Six, Seven,
            Eight, Nine, Ten, Jack, Queen, King, Ace, NoValue =20
        }

        public enum PokerHandType
        {
            Nothing = 0,
            HighCard = 1,
            Pair,
            TwoPair,
            ThreeOfAKind,
            Straight,
            Flush,
            FullHouse,
            FourOfAKind,
            StraightFlush,
            RoyalFlush
        }

        public struct HandValue
        {
            public int Total { get; set; }
            public int HighCard { get; set; }
            public PokerHandType Type { get; set; }
        }

    }
}
