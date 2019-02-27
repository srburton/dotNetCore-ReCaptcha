using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Integration.ReCaptcha.Attributes
{
    [AttributeUsage(System.AttributeTargets.Method)]
    public class ReCaptchaIgnoreAttribute: Attribute
    {            

    }
}
