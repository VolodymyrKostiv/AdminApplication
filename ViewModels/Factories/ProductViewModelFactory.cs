using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminApplication.ViewModels.Factories
{
    internal class ProductViewModelFactory : IViewModelFactory<ProductViewModel>
    {
        public ProductViewModel CreateViewModel()
        {
            return new ProductViewModel();
        }
    }
}
