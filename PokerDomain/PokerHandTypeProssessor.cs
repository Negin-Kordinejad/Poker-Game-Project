using PokerDomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PokerDomainModel.Contract.ContractValues;

namespace PokerDomain
{
    /// <summary>
    /// Bussiness model to evaluate a poker hand
    /// </summary>
    public class PokerHandTypeProssessor
    {
        private List<Card> _cards;
        private HandValue _handValue;

        public PokerHandTypeProssessor(Hand sortedHand)
        {
            _cards = sortedHand.GetHand;
            _handValue = new HandValue();
            Evaluate();
        }
        public HandValue HandValue
        {
            get
            {
                return _handValue;
            }
        }
        public void Evaluate()
        {
            var len = Enum.GetValues(typeof(PokerHandType)).Length;

            for (var handType = PokerHandType.RoyalFlush;
                (int)handType > 0; handType = handType - 1)
            {
                if (IsValid(handType))
                {
                    switch (handType)
                    {
                        case PokerHandType.RoyalFlush:

                            _handValue.HighCard = (int)_cards.Last().Value;
                            _handValue.Total = (int)_cards.Last().Value;
                            _handValue.Type = PokerHandType.RoyalFlush;
                            return;

                        case PokerHandType.StraightFlush:
                            _handValue.HighCard = (int)_cards.Last().Value;
                            _handValue.Total = (int)_cards.Last().Value;
                            _handValue.Type = PokerHandType.StraightFlush;
                            return;

                        case PokerHandType.FourOfAKind:
                            _handValue.HighCard = (int)_cards.GroupBy(c => c.Value).Where(g => g.Count() == 1).Last().Last().Value;
                            _handValue.Total = (int)(_cards.GroupBy(c => c.Value).Where(g => g.Count() == 4).First().Key);

                            _handValue.Type = PokerHandType.FourOfAKind;
                            return;

                        case PokerHandType.FullHouse:
                            _handValue.HighCard = (int)_cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Last().Last().Value;
                            _handValue.Total = (int)(_cards.GroupBy(c => c.Value).Where(g => g.Count() == 3).First().Key);
                            _handValue.Type = PokerHandType.Pair;


                            _handValue.Type = PokerHandType.FullHouse;
                            return;

                        case PokerHandType.Flush:
                            _handValue.HighCard = (int)_cards.Last().Value;
                            _handValue.Total = (int)_cards.Last().Value;
                            _handValue.Type = PokerHandType.Flush;
                            return;

                        case PokerHandType.Straight:
                            _handValue.HighCard = (int)_cards.Last().Value;
                            _handValue.Total = (int)_cards.Last().Value;
                            _handValue.Type = PokerHandType.Straight;
                            return;

                        case PokerHandType.ThreeOfAKind:
                            _handValue.HighCard = (int)_cards.GroupBy(c => c.Value).Where(g => g.Count() == 1).Last().Last().Value;
                            _handValue.Total = (int)(_cards.GroupBy(c => c.Value).Where(g => g.Count() == 3).First().Key);
                            _handValue.Type = PokerHandType.ThreeOfAKind;
                            return;

                        case PokerHandType.TwoPair:
                            _handValue.HighCard = (int)_cards.GroupBy(c => c.Value).Where(g => g.Count() == 1).Last().Last().Value;
                            _handValue.Total = (int)(_cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Sum(c => (int)c.Key));
                            _handValue.Type = PokerHandType.TwoPair;
                            return;

                        case PokerHandType.Pair:
                            _handValue.HighCard = _cards.GroupBy(c => c.Value).Where(g => g.Count() == 1).Max(c => (int)c.Key);
                            _handValue.Total = (int)(_cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).First().Key);
                            _handValue.Type = PokerHandType.Pair;
                            return;

                        case PokerHandType.HighCard:
                            _handValue.HighCard = (int)_cards.Last().Value;
                            _handValue.Total = (int)_cards.Last().Value;
                            _handValue.Type = PokerHandType.HighCard;
                            return;

                        default:
                            _handValue.HighCard = 0;
                            _handValue.Total = 0;
                            _handValue.Type = PokerHandType.Nothing;
                            return;
                    }
                }
            }

        }
        public bool IsValid(PokerHandType handType)
        {
            switch (handType)
            {
                case PokerHandType.RoyalFlush:
                    return IsValid(PokerHandType.StraightFlush) && _cards[4].Value == CardValue.Ace;
                case PokerHandType.StraightFlush:
                    return IsValid(PokerHandType.Flush) && IsValid(PokerHandType.Straight);
                case PokerHandType.FourOfAKind:
                    return GetGroupByValuekCount(4) == 1;
                case PokerHandType.FullHouse:
                    return IsValid(PokerHandType.ThreeOfAKind) && IsValid(PokerHandType.Pair);
                case PokerHandType.Flush:
                    return GetGroupBySuitCount(5) == 1;
                case PokerHandType.Straight:
                    return (int)_cards[4].Value - (int)_cards[0].Value == 4
                            || _cards[0].Value == CardValue.Ace;
                case PokerHandType.ThreeOfAKind:
                    return GetGroupByValuekCount(3) == 1;
                case PokerHandType.TwoPair:
                    return GetGroupByValuekCount(2) == 2;
                case PokerHandType.Pair:
                    return GetGroupByValuekCount(2) == 1;
                case PokerHandType.HighCard:
                    return GetGroupByValuekCount(1) == 5;
            }
            return false;
        }
        private int GetGroupByValuekCount(int n)
        {
            return _cards.GroupBy(c => c.Value).Count(g => g.Count() == n);
        }
        private int GetGroupBySuitCount(int n)
        {
            return _cards.GroupBy(c => c.Suit).Count(g => g.Count() == n);
        }

    }

}
