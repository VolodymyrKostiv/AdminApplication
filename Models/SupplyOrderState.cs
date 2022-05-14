﻿using System.Collections.Generic;

namespace AdminApplication.Models
{
    public partial class SupplyOrderState
    {
        public SupplyOrderState()
        {
            SupplyOrders = new HashSet<SupplyOrder>();
        }

        public int SupplyOrderStateId { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<SupplyOrder> SupplyOrders { get; set; }
    }
}
