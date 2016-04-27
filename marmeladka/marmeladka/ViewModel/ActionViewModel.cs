namespace marmeladka.ViewModel
{
    public class ActionViewModel
    {
        public System.Guid Id { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid OrdersId { get; set; }

        public OrderViewModel Order { get; set; } // для отображения юзера и времени заказа
    }
}
