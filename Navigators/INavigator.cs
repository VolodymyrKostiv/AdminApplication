
using AdminApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.Navigators
{
    public enum ViewType
    {
        AddEmployee,
        CheckEmployees,
        Shop,
    }

    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
