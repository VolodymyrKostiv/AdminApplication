using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels.Factories
{
    internal class CheckEmployeesViewModelFactory : IViewModelFactory<CheckEmployeesViewModel>
    {
        public CheckEmployeesViewModel CreateViewModel()
        {
            return new CheckEmployeesViewModel();
        }
    }
}
