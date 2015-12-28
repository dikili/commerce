using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MusStore
{
    public class AppUser : IdentityUser
    {
        public string Sex { get; set; }
    }
}