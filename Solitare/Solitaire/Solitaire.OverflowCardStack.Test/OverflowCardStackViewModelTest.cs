using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solitaire.Common.Factories;
using Solitaire.Common.Models;
using Solitaire.OverflowCardStack.ViewModels;

namespace Solitaire.OverflowCardStack.Test
{
    [TestClass]
    public class OverflowCardStackViewModelTest
    {
        [TestMethod]
        //couldnt figure out how to make this work, but what it would do is test the deck stack
        public void TestConstructor()
        {
            IDeckFactory deckFactory = new StandardDeckFactory();
            IDeck deck = deckFactory.CreateDeck();
            ISolitaireGameInstance game = new SolitaireGameInstance(deck);
            IEventAggregator eventAggregator = new EventAggregator();
            var viewModel = new OverflowCardStackViewModel(game, eventAggregator);

            Assert.AreEqual(viewModel.TopCard, game.OverflowStack[game.OverflowStack.Count - 1]); 
            .
            Assert.AreEqual(viewModel.DealtCards.Count, 0);
        }

        [TestMethod]
        public void TestDealStackCommand()
        {
            IDeckFactory deckFactory = new StandardDeckFactory();
            IDeck deck = deckFactory.CreateDeck();
            ISolitaireGameInstance game = new SolitaireGameInstance(deck);
            IEventAggregator eventAggregator = new EventAggregator();
            var viewModel = new OverflowCardStackViewModel(game, eventAggregator);

            // NumCardsPerDeal cards should be dealt.
            viewModel.DealStackCommand.Execute(null);
            Assert.AreEqual(viewModel.DealtCards.Count, OverflowCardStackViewModel.NumCardsPerDeal);
        }
    }
}
