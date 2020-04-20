using System;
using Solitaire.Common.Models;

namespace Solitaire.Common.Events
{
    
    public class CardTransferRequestEventArgs : EventArgs
    {
      
        public Card Card { get; set; }
    }
}
