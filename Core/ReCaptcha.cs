using App.Infra.Integration.ReCaptcha.Facades;
using App.Infra.Integration.ReCaptcha.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Integration.ReCaptcha.Core
{
    public sealed class ReCaptcha
    {
        public string Host = "https://www.google.com/recaptcha/api/";

        public Option Option;

        public List<string> Errors = new List<string>();

        readonly ReCaptchaFacade Facade;

        public ReCaptcha(Option option)
        {
            Option = option;

            Facade = new ReCaptchaFacade(this);         
        }

        public bool IsValid(string response)
        {
            var result = Facade.Verify(new ApiRequest()
            {
                Secret = Option.SecretKey,
                Response = response
            });
            if (result is ApiResponse)
                return true;

            return false;
        }
    }
}
