using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Mvvm;
using Solitaire.Common.Models;

namespace Solitaire.Tableaus.ViewModels
{

    
    public class TableausViewModel : BindableBase
    {
        #region Properties

        /// <summary>
        /// Collection of <see cref="VerticalCardStackViewModel" />.
        /// </summary>
        public ObservableCollection<VerticalCardStackViewModel> StackViewModels
        {
            get { return _stackViewModels; }
            set { SetProperty(ref _stackViewModels, value); }
        }

        #endregion

       //shows whats on the table
        public TableausViewModel(ISolitaireGameInstance gameInstance)
        {
            StackViewModels = new ObservableCollection<VerticalCardStackViewModel>();

            foreach (var tableau in gameInstance.Tableaus)
            {
                StackViewModels.Add(new VerticalCardStackViewModel(tableau));
            }
        }

        #region Fields

        private ObservableCollection<VerticalCardStackViewModel> _stackViewModels;

        #endregion
    }

}