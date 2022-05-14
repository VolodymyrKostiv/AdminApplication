using AdminApplication.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels.Factories
{
    public class ViewModelAbstractFactory : IViewModelAbstractFactory
    {
        private readonly IViewModelFactory<AddEmployeeViewModel> _addEmployeeViewModelFactory;
        private readonly IViewModelFactory<CheckEmployeesViewModel> _checkEmployeesViewModelFactory;

        public ViewModelAbstractFactory(
            IViewModelFactory<AddEmployeeViewModel> addEmployeeViewModelFactory,
            IViewModelFactory<CheckEmployeesViewModel> checkEmployeesViewModelFactory)
        {
            _addEmployeeViewModelFactory = addEmployeeViewModelFactory;
            _checkEmployeesViewModelFactory = checkEmployeesViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AddEmployee:
                    return _addEmployeeViewModelFactory.CreateViewModel();
                case ViewType.CheckEmployees:
                    return _checkEmployeesViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("Invalid ViewModelType");
            }
        }
    }
}
