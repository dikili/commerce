using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Core
{
    public class Image
    {
        public Guid ImageId { get; set; }
    
        public virtual int TopicId { get; set; }

        public string ImagePath { get; set; }
    }
}
