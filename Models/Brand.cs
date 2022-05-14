using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
