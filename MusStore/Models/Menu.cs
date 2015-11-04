using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusStore.Models
{
    public class Menu
    {        
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }
        public string Path { get; set; }
        public string ProductCategory { get; set; }
    }

    public class CategoryCompany
    {
        public Dictionary<string, List<Menu>> CompanyCategory { get; set; }
    
    }
}