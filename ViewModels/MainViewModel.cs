using AdminApplication.Commands;
using AdminApplication.Navigators;
using AdminApplication.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AdminApplication.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public INavigator Navigator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public MainViewModel(INavigator navigator, IViewModelAbstractFactory viewModelFactory)
        {
            Navigator = navigator;
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, viewModelFactory);
        }

        public override void UpdateBindings()
        {
            base.UpdateBindings();
        }
    }
}
