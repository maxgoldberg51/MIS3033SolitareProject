using System.Collections.Generic;

namespace Solitaire.Common.Models
{
  
    public class Foundation : IFoundation
    {
        //creates a list of the card
        public List<Card> Cards { get; set; }

        //top card creation and can be empty      
        public Card TopCard
        {
            get { return Cards.Count == 0 ? null : Cards[Cards.Count - 1]; }
        }

        //what the suits are
        public Card.Suits Suit { get; set; }

        //assigns the suits to cards
        public Foundation(Card.Suits suit)
        {
            Suit = suit;
            Cards = new List<Card>();
        }

        //adds cards
        public bool AddCard(Card card)
        {
            bool accepted;

            // suits have to match
            if (card.Suit != Suit)
            {
                return false;
            }

            if (Cards.Count == 0)
            {
                //aces
                accepted = card.Value == Card.Values.Ace;
            }
            else
            {
                var topCard = Cards[Cards.Count - 1];
                if (topCard.Value == Card.Values.Ace)
                {
                   //aces
                    accepted = card.Value == Card.Values.Two;
                }
                else
                {
                    
                    accepted = topCard.Value == card.Value + 1;
                }
            }

            // cards match and is added to the list of cards created at the top
            if (accepted)
            {
                Cards.Add(card);
            }

            return accepted;
        }
    }
}
