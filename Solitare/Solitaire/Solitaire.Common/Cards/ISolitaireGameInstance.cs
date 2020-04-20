using System.Collections.Generic;

namespace Solitaire.Common.Models
{

   
    public interface ISolitaireGameInstance
    {
        
        // similar to last document
        IDeck Deck { get; set; }

       
        List<Card>[] Tableaus { get; set; }

        
        List<Card> OverflowStack { get; set; }

        
        IDictionary<Card.Suits, IFoundation> Foundations { get; set; }
    }

}