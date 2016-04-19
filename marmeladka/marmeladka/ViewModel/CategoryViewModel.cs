using System;
using System.ComponentModel.DataAnnotations;

namespace marmeladka.ViewModel
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Введите Имя")]
        public string Name { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}
