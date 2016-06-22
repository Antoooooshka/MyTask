using System;
using System.ComponentModel.DataAnnotations;

namespace marmeladka.ViewModel
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Имя категории обазательно")]
        public string Name { get; set; }
        public bool? IsDelete { get; set; }
    }
}
