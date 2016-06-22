using System;

namespace marmeladka.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public int CurrentWeight { get; set; }
        public int ProductCost { get; set; }
    }
}