using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Prism.Mvvm;

namespace Solitaire.Common.Models
{

    //ceates an instance of the game
    public class SolitaireGameInstance : BindableBase, ISolitaireGameInstance
    {
        #region Constants

        /// <summary>
        /// Number of tableaus.
        /// </summary>
        public const int NumTableaus = 7;

        #endregion

        #region Properties

        /// <summary>
        /// Deck of cards.
        /// </summary>
        public IDeck Deck
        {
            get { return _deck; }
            set { SetProperty(ref _deck, value); }
        }

        /// <summary>
        /// List of tableaus.
        /// </summary>
        public List<Card>[] Tableaus
        {
            get { return _tableaus; }
            set { SetProperty(ref _tableaus, value); }
        }

        /// <summary>
        /// Overflow stack of cards.
        /// </summary>
        public List<Card> OverflowStack
        {
            get { return _overflowStack; }
            set { SetProperty(ref _overflowStack, value); }
        }

        /// <summary>
        /// List of tableaus.
        /// </summary>
        public IDictionary<Card.Suits, IFoundation> Foundations
        {
            get { return _foundations; }
            set { SetProperty(ref _foundations, value); }
        }

        #endregion

        //enables shuffle and overflow and distribution of the deck
        public SolitaireGameInstance(IDeck deck)
        {
            deck.Shuffle();
            Deck = deck;
            CreateTableaus();
            CreateOverflowStack();
            Foundations = new Dictionary<Card.Suits, IFoundation>();
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                Foundations.Add(suit, new Foundation(suit));
            }
        }

        private void CreateTableaus()
        {
            Tableaus = new List<Card>[NumTableaus];
            for (int tableauIndex = 0, rangeIndex = 0; tableauIndex < NumTableaus; tableauIndex++)
            {
                var numCards = tableauIndex + 1;
                Tableaus[tableauIndex] = Deck.Cards.GetRange(rangeIndex, numCards);
                rangeIndex = numCards+ rangeIndex;
            }
        }

        private void CreateOverflowStack()
        {
            var numCardsInTableaus = 0;
            Tableaus.ToList().ForEach(t => numCardsInTableaus += t.Count);
            OverflowStack = Deck.Cards.GetRange(numCardsInTableaus,
                Deck.Cards.Count - numCardsInTableaus);
        }

        #region Fields

        private IDeck _deck;
        private List<Card>[] _tableaus;
        private List<Card> _overflowStack;
        private IDictionary<Card.Suits, IFoundation> _foundations;

        #endregion
    }

}