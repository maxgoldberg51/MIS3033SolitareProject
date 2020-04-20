using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire.Common.Factories;
using Solitaire.Common.Models;

namespace Solitaire.Common.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestAddCard()
        {
            //this creates a card with value and suit
            var card = new Card
            {
                Suit = Card.Suits.Spades,
                Value = Card.Values.Ace
            };
           
            //this adds the card just created to the foundation and makes sure it is valid and accepted
            IFoundation foundation = new Foundation(card.Suit);
            bool accepted = foundation.AddCard(card);
            Assert.IsTrue(accepted);
        }

        [TestMethod]
        public void TestAddCardIncorrectSuit()
        {
            //same as above
            var card = new Card
            {
                Suit = Card.Suits.Spades,
                Value = Card.Values.Ace
            };
            // same as above, but the IsFalse wants a different card than above
            IFoundation foundation = new Foundation(Card.Suits.Clubs);
            bool accepted = foundation.AddCard(card);
            Assert.IsFalse(accepted);
        }

        [TestMethod]
        public void TestAddCardCorrectOrder()
        {
            
            var card1 = new Card
            {
                Suit = Card.Suits.Spades,
                Value = Card.Values.Ace
            };
            
            var card2 = new Card
            {
                Suit = Card.Suits.Spades,
                Value = Card.Values.Two
            };
            
            IFoundation foundation = new Foundation(card1.Suit);
            foundation.AddCard(card1);
            bool accepted = foundation.AddCard(card2);
            Assert.IsTrue(accepted);
        }

        [TestMethod]
        public void TestAddCardIncorrectOrder()
        {
            
            var card1 = new Card
            {
                Suit = Card.Suits.Spades,
                Value = Card.Values.Ace
            };
            
            var card2 = new Card
            {
                Suit = Card.Suits.Spades,
                Value = Card.Values.Three
            };

            IFoundation foundation = new Foundation(card1.Suit);
            foundation.AddCard(card1);
            bool accepted = foundation.AddCard(card2);
            Assert.IsFalse(accepted);
        }

        [TestMethod]
        public void TestAddCardFullFoundation()
        {
            var suit = Card.Suits.Spades;
            IFoundation foundation = new Foundation(suit);
            Card card = null;
          
            //makes sure all cards are different and fills the deck
            foreach (Card.Values value in Enum.GetValues(typeof(Card.Values)))
            {
                card = new Card
                {
                    Suit = suit,
                    Value = value
                };
                foundation.AddCard(card);
            }
          

            bool accepted = foundation.AddCard(card);
            Assert.IsFalse(accepted);
        }
    }
}
