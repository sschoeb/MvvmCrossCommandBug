using System;
using System.Windows.Input;

using Cirrious.MvvmCross.ViewModels;

namespace CommandBug.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {

        private bool isEnabled = true;

        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                ((MvxCommand)ClickCommand).RaiseCanExecuteChanged();
            }
        }

        public FirstViewModel()
        {
            ClickCommand = new MvxCommand(ClickCommandExecute, ClickCommandCanExecute);
            DisableCommand = new MvxCommand(() => { IsEnabled = !IsEnabled; });
            GCCommand = new MvxCommand(GC.Collect);
        }

        private bool ClickCommandCanExecute()
        {
            return IsEnabled;
        }

        private void ClickCommandExecute()
        {
            
        }

        public ICommand ClickCommand { get; set; }

        public ICommand DisableCommand { get; set; }

        public ICommand GCCommand { get; set; }

    }
}
