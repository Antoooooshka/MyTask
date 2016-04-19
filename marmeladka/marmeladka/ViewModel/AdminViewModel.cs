using System;
using System.ComponentModel.DataAnnotations;

namespace marmeladka.ViewModel
{
    public class AdminViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Salt { get; set; }
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
    }
}