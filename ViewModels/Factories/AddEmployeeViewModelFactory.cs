using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels.Factories
{
    public class AddEmployeeViewModelFactory : IViewModelFactory<AddEmployeeViewModel>
    {
        public AddEmployeeViewModel CreateViewModel()
        {
            return new AddEmployeeViewModel();
        }
    }
}
