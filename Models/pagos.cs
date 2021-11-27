using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPagos.Models
{
    public class pagos
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public double UnitPrice { get; set; }

        public double TotalPrice { get; set; }

    }
}
