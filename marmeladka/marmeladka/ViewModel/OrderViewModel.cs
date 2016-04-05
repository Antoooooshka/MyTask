using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marmeladka.ViewModels
{
    public class OrderViewModel
    {
        public System.Guid Id { get; set; }
        public System.DateTime Order_time { get; set; }
        public System.Guid userId { get; set; }
    }
}
