using PokerDomainModel.Contract;
using PokerDomainModel.Model;
using System;
using System.Collections.Generic;

namespace PokerDomain
{
    public interface IDealCarts
    {
        Tuple<string, int> Deal(string Player1Name, string Player2Name, string playersHands);
      
    }
}