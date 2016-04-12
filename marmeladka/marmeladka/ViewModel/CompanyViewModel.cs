using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marmeladka.ViewModels
{
    public class CompanyViewModel
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required(ErrorMessage = "Имя не указано")]
        public string Name { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
