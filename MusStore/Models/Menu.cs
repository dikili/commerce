using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusStore.Models
{
    public class Menu
    {
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public DateTime Created { get; set; }
        //public bool Flagged { get; set; }
        

        public int CompanyId { get; set; }

        public bool isVisible { get; set; }
        
        public string CompanyName { get; set; }
        public string Path { get; set; }
        public string ProductCategory { get; set; }
    }
}