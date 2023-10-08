using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreViewApp.Domain
{
    public sealed class Order
    {
        public int Id { get; set; }
        public List<Product> Product { get; set; }
        public decimal Discount { get; set; }
        public int QtdItens => Product.Count;
        public decimal ValorTotal{ get; set; }
    }
}
