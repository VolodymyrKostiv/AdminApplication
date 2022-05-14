using AdminApplication.Commands;
using AdminApplication.DTOs;
using AdminApplication.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace AdminApplication.ViewModels
{
    public class ShopViewModel : ViewModelBase
    {
        private IHttpAPIHelper<ShopDTO> _htppShopHelper;
        private IHttpAPIHelper<StorageDTO> _htppStorageHelper;

        private ShopDTO _selectedShop;
        private StorageDTO _selectedStorage;

        public ShopDTO SelectedShop
        {
            get =>  _selectedShop;
            set
            {
                _selectedShop = value;
                OnPropertyChanged(nameof(_selectedShop));
            }
        }
        public StorageDTO SelectedStorage
        {
            get => _selectedStorage;
            set
            {
                _selectedStorage = value;
                OnPropertyChanged(nameof(_selectedStorage));
            }
        }

        public IEnumerable<ShopDTO> Shops { get; set; }
        public IEnumerable<StorageDTO> Storages { get; set; }

        public string ShopAddress { get; set; }
        public int ShopStorageId { get; set; }
        public double StorageArea { get; set; }

        public RelayCommand SubmitShop { get; set; }
        public RelayCommand SubmitStorage { get; set; }

        public ShopViewModel()
        {
            _htppShopHelper = new HttpAPIHelper<ShopDTO>();
            _htppStorageHelper = new HttpAPIHelper<StorageDTO>();

            Task.Run(LoadShops);
            Task.Run(LoadStorages);
            InitializeCommand();
        }

        public void InitializeCommand()
        {
            SubmitShop = new RelayCommand(SelectSubmitShop);
            SubmitStorage = new RelayCommand(SelectSubmitStorage);
        }

        private async void SelectSubmitShop(object obj)
        {
            if (MessageBox.Show("Do you want to create new shop?", "Create shop", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                var shop = new ShopDTO() { Address = ShopAddress, StorageId = ShopStorageId };
                
                try
                {
                    if (await _htppShopHelper.PostRequest("shops", shop) != null)
                    {
                        MessageBox.Show("Shop was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error during adding shop", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                UpdateBindings();
            }
        }

        private async void SelectSubmitStorage(object obj)
        {
            if (MessageBox.Show("Do you want to create new storage?", "Create storage", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                var storage = new StorageDTO() { Area = StorageArea };

                try
                {
                    if (await _htppStorageHelper.PostRequest("storages", storage) != null)
                    {
                        MessageBox.Show("storage was successfully added", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error during adding storage", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                UpdateBindings();
            }
        }

        private async Task LoadShops()
        {
            try
            {
                Shops = await _htppShopHelper.GetMultipleItemsRequest("shops");
                OnPropertyChanged(nameof(Shops));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async Task LoadStorages()
        {
            try
            {
                Storages = await _htppStorageHelper.GetMultipleItemsRequest("storages");
                OnPropertyChanged(nameof(Storages));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateShop(ShopDTO shop)
        {
            try
            {
                _htppShopHelper.PutRequest("shops", shop);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void UpdateStorage(StorageDTO storage)
        {
            try
            {
                _htppStorageHelper.PutRequest("storages", storage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        public override void UpdateBindings()
        {
            base.UpdateBindings();
            OnPropertyChanged(nameof(Shops));
            OnPropertyChanged(nameof(Storages));
        }
    }
}
