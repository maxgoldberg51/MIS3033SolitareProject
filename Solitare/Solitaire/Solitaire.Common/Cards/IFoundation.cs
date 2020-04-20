using System.Collections.Generic;

namespace Solitaire.Common.Models
{
    
    public interface IFoundation
    {
        
        //references all that we did in the previous documents in this folder
        List<Card> Cards { get; set; }

        
        Card TopCard { get; }

       
        Card.Suits Suit { get; set; }

        
        bool AddCard(Card card);
    }

}