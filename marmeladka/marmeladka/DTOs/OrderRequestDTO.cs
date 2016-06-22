using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using marmeladka.ViewModel;

namespace marmeladka.DTOs
{
    public class OrderRequestDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Second_name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public decimal? OrderPrice { get; set; }
        public List<ProductOrderDTO> ProductList { get; set; } 
    }
}