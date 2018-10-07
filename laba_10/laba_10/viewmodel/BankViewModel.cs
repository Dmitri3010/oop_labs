using laba_10.commands;
using laba_10.Models;
using laba_10.viewmodel;
using System.Linq;
using System.Windows.Input;

namespace laba_10.ViewModels
{
    class BankViewModel : ViewModelBase
    {
        public Bank Vklad;

        public BankViewModel(Bank vklad)
        {
            this.Vklad = vklad;
        }

        public string Title
        {
            get { return Vklad.Title; }
            set
            {
                Vklad.Title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Name
        {
            get { return Vklad.Name; }
            set
            {
                Vklad.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Count
        {
            get { return Vklad.Count; }
            set
            {
                Vklad.Count = value;
                OnPropertyChanged("Count");
            }
        }

        public string Date
        {
            get { return Vklad.Date; }
            set
            {
                Vklad.Date = value;
                OnPropertyChanged("Date");
            }
        }

        #region Commands

        #region Забрать

        private DelegateCommand getItemCommand;

        public ICommand GetItemCommand
        {
            get
            {
                if (getItemCommand == null)
                {
                    getItemCommand = new DelegateCommand(GetItem);
                }
                return getItemCommand;
            }
        }

        private void GetItem()
        {
            Count++;
        }

        #endregion

        #region Выдать

        private DelegateCommand giveItemCommand;

        public ICommand GiveItemCommand
        {
            get
            {
                if (giveItemCommand == null)
                {
                    giveItemCommand = new DelegateCommand(GiveItem, CanGiveItem);
                }
                return giveItemCommand;
            }
        }

        private void GiveItem()
        {
            Count--;
        }

        private bool CanGiveItem()
        {
            return Count > 0;
        }

        #endregion

        #endregion
    }
}


