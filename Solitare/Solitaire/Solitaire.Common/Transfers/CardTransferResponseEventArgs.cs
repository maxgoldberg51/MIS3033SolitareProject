using System;
using Solitaire.Common.Models;

namespace Solitaire.Common.Events
{
   
    public class CardTransferResponseEventArgs : EventArgs
    {
       
        public Card Card { get; set; }

        //is accepted (valid)
        public bool Accepted { get; set; }
    }
}
