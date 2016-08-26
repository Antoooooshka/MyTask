using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KudaPostupat.Models
{
    public class UniversityViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int CountryId { get; set; }
        public int RegionId { get; set; }
        public int CityId { get; set; }
        public string WebSite { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
    }
}