using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusStore.Models
{
    public class TopicImageViewModel
    {
        public string Title { get; set; }
      
        public string Body { get; set; }
        
        public List<string> ImagePath { get; set; }
    }
}