using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Web;

namespace MusStore.Data
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title  { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public DateTime Created { get; set; }
        //public bool Flagged { get; set; }
        public string Path { get; set; }
       public ICollection<Reply> Replies { get; set; }
        public int CompanyId { get; set; }

    }
}