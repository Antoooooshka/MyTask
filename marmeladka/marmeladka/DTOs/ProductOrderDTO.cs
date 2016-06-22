using System;

namespace marmeladka.DTOs
{
    public class ProductOrderDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int ProductWeight { get; set; }
        public decimal? Retail_price { get; set; }
        public decimal? TotalCategoryPrice { get; set; }
        public int CurrentWeight { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CompanyId { get; set; }
    }
}