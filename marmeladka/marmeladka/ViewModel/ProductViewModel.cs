using marmeladka.core.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marmeladka.ViewModels
{
    public class ProductViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Opt_price { get; set; }
        public decimal? Retail_price { get; set; }
        public System.Guid CategoryId { get; set; }
        public int? Product_weight { get; set; }
        public System.Guid CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
