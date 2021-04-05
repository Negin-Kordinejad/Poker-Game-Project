using PokerDomainModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using static PokerDomainModel.Contract.ContractValues;

namespace PokerDomain
{
    public class DealCarts : IDealCarts
    {
        private Hand player1Hand;
        private Hand player2Hand;
        private Hand sortedPlayer1Hand;
        private Hand sortedPlayer2Hand;
        PokerHandTypeProssessor _handProcceor1, _handProcceor2;
        public DealCarts()
        {

        }

        public Tuple<string, int> Deal(string Player1Name, string Player2Name, string playersHands)
        {
            //To Do :Need to refactor with DI
            sortedPlayer1Hand = new Hand();
            sortedPlayer2Hand = new Hand();
            HandInit(playersHands);
            sortCards();
            _handProcceor1 = new PokerHandTypeProssessor(sortedPlayer1Hand);
            _handProcceor2 = new PokerHandTypeProssessor(sortedPlayer2Hand);


            if (_handProcceor1.HandValue.Type > _handProcceor2.HandValue.Type)
            {
                return Tuple.Create(Player1Name, 1);
            }
            else if (_handProcceor1.HandValue.Type < _handProcceor2.HandValue.Type)
            {
                return Tuple.Create(Player2Name, 1);
            }
            else //if the hands are the same, evaluate the values
            {
                if (_handProcceor1.HandValue.Total > _handProcceor2.HandValue.Total)
                {
                    return Tuple.Create(Player1Name, 1);
                }

                else if (_handProcceor1.HandValue.Total < _handProcceor2.HandValue.Total)
                {
                    return Tuple.Create(Player2Name, 1);
                }
                //if the values are the same, evaluate the highCard
                else if (_handProcceor1.HandValue.HighCard > _handProcceor2.HandValue.HighCard)
                {
                    return Tuple.Create(Player1Name, 1);
                }
                else if (_handProcceor1.HandValue.HighCard < _handProcceor2.HandValue.HighCard)
                {
                    return Tuple.Create(Player2Name, 1);
                }
                else
                {
                    //if the highcards are the same, evaluate the next highCard
                    // To Do : nedd to make it recersive
                    int NextHighCard1 = GetNextCard(_handProcceor1.HandValue.HighCard, sortedPlayer1Hand.GetHand);
                    int NextHighCard2 = GetNextCard(_handProcceor2.HandValue.HighCard, sortedPlayer2Hand.GetHand);
                    int i = 3;
                    do
                    {
                        if (NextHighCard1 > NextHighCard2)
                            return Tuple.Create(Player2Name, 1);

                        if (NextHighCard1 < NextHighCard2)
                            return Tuple.Create(Player2Name, 1);

                        NextHighCard1 = GetNextCard(NextHighCard1, sortedPlayer1Hand.GetHand);
                        NextHighCard2 = GetNextCard(NextHighCard2, sortedPlayer2Hand.GetHand);
                        --i;
                    } while (i >= 0);

                    return null;
                }
            }
        }

        public int GetNextCard(int maxValue, List<Card> sortedList)
        {
            int h = sortedList.GroupBy(c => c.Value)
                .Max(c =>
            {
                if ((int)c.Key < maxValue)
                    return (int)c.Key;
                return 0;
            });
            return h;
        }
        /// <summary>
        /// Make the data models with transfering data from input string format 
        /// </summary>
        /// <param name="Inithands"></param>
        public void HandInit(string Inithands)
        {
            var HandP = Inithands.Split(new char[0]).ToList();
            var HandP1 = HandP.Take(5).ToList();
            var HandP2 = HandP.GetRange(5, 5).ToList();
            List<Card> carts1 = new List<Card>();
            List<Card> carts2 = new List<Card>();

            HandP1.ForEach(c =>
            {
                carts1.Add(new Card(GetCartValue(c[0]), GetCartSuit(c[1])));
            });
            player1Hand = new Hand(carts1);

            HandP2.ForEach(c =>
            {
                carts2.Add(new Card(GetCartValue(c[0]), GetCartSuit(c[1])));
            });
            player2Hand = new Hand(carts2);
        }
        public CardValue GetCartValue(char firstChar)
        {
            if (Char.IsDigit(firstChar))
            {
                int t = (int)Char.GetNumericValue(firstChar);
                foreach (CardValue mc in Enum.GetValues(typeof(CardValue)))
                    if (mc.ToString().StartsWith(((CardValue)(t)).ToString()))
                        return mc;
            }
            else
            {
                foreach (CardValue mc in Enum.GetValues(typeof(CardValue)))
                    if ((int)mc > 9 && mc.ToString().StartsWith(firstChar.ToString().ToUpper()))
                        return mc;
            }
            return CardValue.NoValue;
        }
        public Suit GetCartSuit(Char firstChar)
        {
            foreach (Suit mc in Enum.GetValues(typeof(Suit)))
                if (mc.ToString().StartsWith(firstChar.ToString()))
                    return mc;

            return 0;
        }
        public void sortCards()
        {
            sortedPlayer1Hand.GetHand.Clear();
            sortedPlayer1Hand.GetHand.Clear();
            var queryPlayer = from hand in player1Hand.GetHand
                              orderby hand.Value
                              select hand;

            var queryComputer = from hand in player2Hand.GetHand
                                orderby hand.Value
                                select hand;


            foreach (var element in queryPlayer.ToList())
            {
                sortedPlayer1Hand.GetHand.Add(element);
            }


            foreach (var element in queryComputer.ToList())
            {
                sortedPlayer2Hand.GetHand.Add(element);
            }
        }
    }
}
