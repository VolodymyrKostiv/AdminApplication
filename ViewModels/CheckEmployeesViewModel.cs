using AdminApplication.DTOs;
using AdminApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class CheckEmployeesViewModel : ViewModelBase
    {
        public ObservableCollection<EmployeeDTO> Employees { get; set; }
        private IHttpAPIHelper<EmployeeDTO> _httpHelper;

        private EmployeeDTO _selectedEmployee;
        public EmployeeDTO SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged(nameof(_selectedEmployee));
            }
        }

        public CheckEmployeesViewModel()
        {
            _httpHelper = new HttpAPIHelper<EmployeeDTO>();
            LoadEmployees();
        }

        private async void LoadEmployees()
        {
            try
            {
                var x = await _httpHelper.GetMultipleItemsRequest($"employees");
                Employees = new ObservableCollection<EmployeeDTO>(x);
                OnPropertyChanged(nameof(Employees));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateEmployee(EmployeeDTO em)
        {
            try
            {
                _httpHelper.PutRequest("employees", SelectedEmployee);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public override void UpdateBindings()
        {
            base.UpdateBindings();
            LoadEmployees();
        }
    }
}
