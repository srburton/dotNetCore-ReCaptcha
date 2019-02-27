using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Integration.ReCaptcha.Models
{
    public class Option
    {
        public string PublicKey { get; set; }

        public string SecretKey { get; set; }

        public string Redirect { get; set; }
    }
}
