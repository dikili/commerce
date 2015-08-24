using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MusStore.Services
{
    public class MockMailService :IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            Debug.Write("mock service called");
            return true;
        }
    }
}