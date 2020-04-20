using Solitaire.Common.Models;

namespace Solitaire.Common.Factories
{
    
    public interface ISolitaireGameInstanceFactory
    {
        //creates the Game
        ISolitaireGameInstance CreateGameInstance();
    }
}
