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
        private readonly IViewModelFactory<ShopViewModel> _shopViewModelFactory;
        private readonly IViewModelFactory<ProductViewModel> _productViewModelFactory;

        public ViewModelAbstractFactory(
            IViewModelFactory<AddEmployeeViewModel> addEmployeeViewModelFactory,
            IViewModelFactory<CheckEmployeesViewModel> checkEmployeesViewModelFactory,
            IViewModelFactory<ShopViewModel> shopViewModelFactory,
            IViewModelFactory<ProductViewModel> productViewModelFactory)
        {
            _addEmployeeViewModelFactory = addEmployeeViewModelFactory;
            _checkEmployeesViewModelFactory = checkEmployeesViewModelFactory;
            _shopViewModelFactory = shopViewModelFactory;
            _productViewModelFactory = productViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.AddEmployee:
                    return _addEmployeeViewModelFactory.CreateViewModel();
                case ViewType.CheckEmployees:
                    return _checkEmployeesViewModelFactory.CreateViewModel();
                case ViewType.Shop:
                    return _shopViewModelFactory.CreateViewModel();
                case ViewType.Product:
                    return _productViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("Invalid ViewModelType");
            }
        }
    }
}
