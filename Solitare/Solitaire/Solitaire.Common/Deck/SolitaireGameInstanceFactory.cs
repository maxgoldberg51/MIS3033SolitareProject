using Solitaire.Common.Models;

namespace Solitaire.Common.Factories
{
    
    public class SolitaireGameInstanceFactory : ISolitaireGameInstanceFactory
    {
        //adds the deck to the game
        public ISolitaireGameInstance CreateGameInstance()
        {
            IDeckFactory deckFactory = new StandardDeckFactory();
            IDeck deck = deckFactory.CreateDeck();
            ISolitaireGameInstance gameInstance = new SolitaireGameInstance(deck);
            return gameInstance;
        }
    }
}
