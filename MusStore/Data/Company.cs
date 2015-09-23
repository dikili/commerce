using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusStore.Data
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("Id")]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}