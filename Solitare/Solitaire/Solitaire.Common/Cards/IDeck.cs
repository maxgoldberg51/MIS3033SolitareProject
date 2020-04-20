using System.Collections.Generic;

namespace Solitaire.Common.Models
{
    
    public interface IDeck
    {
        //creates a set of cards inside of the previously created card class
        List<Card> Cards { get; set; }

        //creates shuffle of the deck
        void Shuffle();
    }

}