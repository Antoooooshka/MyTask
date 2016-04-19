using System.ComponentModel.DataAnnotations;

namespace marmeladka.ViewModel
{
    public class CompanyViewModel
    {
        [Required]
        public System.Guid Id { get; set; }
        [Required(ErrorMessage = "Имя не указано")]
        public string Name { get; set; }
        public bool? IsDelete { get; set; }
    }
}
