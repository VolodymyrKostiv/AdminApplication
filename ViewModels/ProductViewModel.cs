using AdminApplication.Commands;
using AdminApplication.Helpers;
using AdminApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels
{
    public class ProductViewModel : ViewModelBase
    {
        private IHttpAPIHelper<FullProductInfo> _httpAPIHelper;

        public FullProductInfo ProductCreate { get; set; }

        public RelayCommand SubmitProduct { get; set; }

        public ProductViewModel()
        {
            _httpAPIHelper = new HttpAPIHelper<FullProductInfo>();
            LoadProducts();
        }

        private ObservableCollection<FullProductInfo> _products;
        public ObservableCollection<FullProductInfo> Products
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private FullProductInfo _selectedProduct;
        public FullProductInfo SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private async Task LoadProducts()
        {
            try
            {
                IEnumerable<FullProductInfo> res = await _httpAPIHelper.GetMultipleItemsRequest("products");
                Products = new ObservableCollection<FullProductInfo>(res);
                OnPropertyChanged(nameof(Products));
                UpdateBindings();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
