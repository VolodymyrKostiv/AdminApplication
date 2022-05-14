using AdminApplication.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels.Factories
{
    public interface IViewModelAbstractFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
