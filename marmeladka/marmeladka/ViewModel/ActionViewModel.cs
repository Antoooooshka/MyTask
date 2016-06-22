namespace marmeladka.ViewModel
{
    public class ActionViewModel
    {
        public System.Guid Id { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid OrdersId { get; set; }
        public int? CurrentProductWeight { get; set; }

        public OrderViewModel Order { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
