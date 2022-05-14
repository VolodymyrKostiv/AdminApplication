using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels.Factories
{
    internal class ShopViewModelFactory : IViewModelFactory<ShopViewModel>
    {
        public ShopViewModel CreateViewModel()
        {
            return new ShopViewModel();
        }
    }
}
