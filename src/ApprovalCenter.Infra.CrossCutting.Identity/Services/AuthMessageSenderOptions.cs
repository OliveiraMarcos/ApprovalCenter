using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Infra.CrossCutting.Identity.Services
{
    public class AuthMessageSenderOptions
    {
        public string SmptHost { get; set; }
        public Int32 SmptPort { get; set; }
        public bool EnableSsl { get; set; }
        public string UserCredential { get; set; }
        public string PassCredential { get; set; }
    }
}
