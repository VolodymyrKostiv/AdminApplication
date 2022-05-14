using AdminApplication.Commands;
using AdminApplication.DTOs;
using AdminApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApplication.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        IHttpAPIHelper<EmployeeDTO> _httpApi;

        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _Login { get; set; }
        public string _Password { get; set; }
        public int _ShopID { get; set; }
        public string _EmployeeType { get; set; }
        public string _PhoneNumber { get; set; }
        public bool IsManager { get; set; }
        public bool IsSeller { get; set; }

        public RelayCommand AddToReceiptCommand { get; set; }

        public AddEmployeeViewModel()
        {
            AddToReceiptCommand = new RelayCommand(AddEmployee);
            _httpApi = new HttpAPIHelper<EmployeeDTO>();
        }

        public async void AddEmployee(object? par)
        {
            if (MessageBox.Show("Do you want to create new employee?", "Create user", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {

                EmployeeDTO dto = new EmployeeDTO()
                {
                    FirstName = _FirstName,
                    LastName = _LastName,
                    Login = _Login,
                    Password = _Password,
                    ShopID = _ShopID,
                    PhoneNumber = _PhoneNumber,
                    EmployeeType = IsManager ? "Manager" : "Seller",
                };

                try
                {
                    if (await _httpApi.PostRequest("employees", dto) != null)
                    {
                        MessageBox.Show("User was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error during adding user", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                { }

                UpdateBindings();
            }
        }

    }
}
