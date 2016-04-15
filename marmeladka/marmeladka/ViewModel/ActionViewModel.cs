using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marmeladka.ViewModels
{
    public class ActionViewModel
    {
        public System.Guid Id { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid OrdersId { get; set; }
    }
}
