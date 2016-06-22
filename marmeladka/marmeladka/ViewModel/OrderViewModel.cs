using System;

namespace marmeladka.ViewModel
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime Order_time { get; set; }
        public Guid userId { get; set; }
        public decimal? OrderPrice { get; set; }
        public int? OrderWeight { get; set; }

        public UserViewModel User{ get; set; }
    }
}
