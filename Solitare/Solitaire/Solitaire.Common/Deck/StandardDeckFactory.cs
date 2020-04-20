using System;
using System.Collections.Generic;
using Solitaire.Common.Models;

namespace Solitaire.Common.Factories
{

  
    public class StandardDeckFactory : IDeckFactory
    {
        //gives value to the cards (numbers and the suits)
        public IDeck CreateDeck()
        {
            var deck = new StandardDeck
            {
                Cards = new List<Card>(StandardDeck.NumCards)
            };

            foreach (Card.Values value in Enum.GetValues(typeof (Card.Values)))
            {
                foreach (Card.Suits suit in Enum.GetValues(typeof (Card.Suits)))
                {
                    var card = new Card
                    {
                        Value = value,
                        Suit = suit
                    };
                    deck.Cards.Add(card);
                }
            }

            return deck;
        }
    }

}