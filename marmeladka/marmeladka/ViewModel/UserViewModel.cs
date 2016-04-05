using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marmeladka.ViewModels
{
    public class UserViewModel
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string Second_name { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public int Postcode { get; set; }
    }
}
