using System;
using System.ComponentModel.DataAnnotations;

namespace marmeladka.ViewModel
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage="Обязательное поле")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Opt_price { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Retail_price { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public Guid CategoryId { get; set; }
        public int? Product_weight { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public Guid CompanyId { get; set; }
        public CompanyViewModel Company { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
