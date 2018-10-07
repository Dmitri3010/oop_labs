using laba_10.Models;
using laba_10.viewmodel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_10.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<BankViewModel> BanksList { get; set; }

        #region Constructor

        public MainViewModel(List<Bank> vklads)
        {
            BanksList = new ObservableCollection<BankViewModel>(vklads.Select(b => new BankViewModel(b)));
        }

        #endregion
    }
}
