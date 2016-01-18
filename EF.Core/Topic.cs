using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Web;

namespace EF.Core
{
    public class Topic
    {
        public Topic()
        {
            isVisible = true;
            ProductCategory = "General";
           
        }
        public int Id { get; set; }
        
        public string Title  { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public DateTime Created { get; set; }
        //public bool Flagged { get; set; }
        //since more than 1 image will be assignable ,this means that instead of path
        //we need to store the imageId here instead changed --> public string Path { get; set; }
        public Guid ImageId { get; set; }
    
        public int CompanyId { get; set; }

        public bool isVisible { get; set; }

        public string  ProductCategory { get; set; }
  
    }
}