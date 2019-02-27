using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Integration.ReCaptcha.Models
{
    public class ApiRequest
    {
        public string Secret { get; set; }

        public string Response { get; set; }

        public string Remoteip { get; set; }
    }
}
