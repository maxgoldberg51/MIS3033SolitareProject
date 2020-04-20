using Solitaire.Common.Models;

namespace Solitaire.Common.Factories
{

   
    public interface IDeckFactory
    {
        //Creates the Deck
        IDeck CreateDeck();
    }

}