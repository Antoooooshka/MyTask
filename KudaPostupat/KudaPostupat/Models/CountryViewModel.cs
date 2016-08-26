using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KudaPostupat.Models
{
    public class CountryViewModel
    {
        public Guid CountryId { get; set; }
        public string Title_ru { get; set; }
        public string Title_ua { get; set; }
        public string Title_en { get; set; }
    }
}