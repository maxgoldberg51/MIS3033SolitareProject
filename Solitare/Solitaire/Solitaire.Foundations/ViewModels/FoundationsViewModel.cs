using System.Collections.Generic;
using Microsoft.Practices.Prism.Mvvm;
using Microsoft.Practices.Prism.PubSubEvents;
using Solitaire.Common.Events;
using Solitaire.Common.Models;

namespace Solitaire.Foundations.ViewModels
{
    public class FoundationsViewModel : BindableBase
    {
        #region Properties

        /// <summary>
        /// Foundations.
        /// </summary>
        public IDictionary<Card.Suits, IFoundation> Foundations { get; set; }

        #endregion

        //new foundation
        public FoundationsViewModel(ISolitaireGameInstance gameInstance, IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Foundations = new Dictionary<Card.Suits, IFoundation>(gameInstance.Foundations);
            _eventAggregator.GetEvent<CardTransferRequestEvent>().Subscribe(AcceptCard);
        }

        private void AcceptCard(CardTransferRequestEventArgs request)
        {
            var foundation = Foundations[request.Card.Suit];
            var accepted = foundation.AddCard(request.Card);
            
            //lets us transffer cards
            var result = new CardTransferResponseEventArgs
            {
                Card = request.Card,
                Accepted = accepted
            };
            _eventAggregator.GetEvent<CardTransferResponseEvent>().Publish(result);
        }

        #region Fields

        private readonly IEventAggregator _eventAggregator;

        #endregion
    }
}
