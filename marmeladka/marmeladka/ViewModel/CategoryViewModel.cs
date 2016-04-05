﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marmeladka.ViewModels
{
    public class CategoryViewModel
    {
        public System.Guid Id { get; set; }

        [Required(ErrorMessage = "Введите Имя")]
        public string Name { get; set; }
    }
}
