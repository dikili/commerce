﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF.Core
{
    public class Reply
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Create { get; set; }

        public int TopicId { get; set; }
    }
}
