using App.Infra.Integration.ReCaptcha.Attributes;
using App.Infra.Integration.ReCaptcha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;


namespace App.Infra.Integration.ReCaptcha.Filters
{
    public class ReCaptchaActionFilter : Attribute, IActionFilter
    {
        protected Core.ReCaptcha _reCaptcha { get; set; }

        public ReCaptchaActionFilter(Action<Option> setupAction)
        {
            var option = new Option();

            setupAction.Invoke(option);

            _reCaptcha = new Core.ReCaptcha(option);

            ReCaptchaPublicConfig.PublicKey = option.PublicKey;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
                  
        }

        public void OnActionExecuting(ActionExecutingContext context)

        {
            try
            {
                var baseController = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor;

                var responseReCaptcha = context.HttpContext.Request.Cookies.FirstOrDefault(x => x.Key == "g-recaptcha").Value ?? string.Empty;
                                                         
                //Atributo padrão na class 
                var reCapController = baseController.ControllerTypeInfo
                                                    ?.GetCustomAttribute<ReCaptchaAttribute>(true);

                //Pegar atributo padrão no metodo
                var reCapAction = baseController.MethodInfo
                                                .GetCustomAttribute<ReCaptchaAttribute>();

                //Atributo [Ignore] padrão no metodo            
                var reCapIgnore = baseController.MethodInfo
                                                ?.GetCustomAttribute<ReCaptchaIgnoreAttribute>();

                //Regra para o atributo
                CheckAttribute(responseReCaptcha,
                               reCapController,
                               reCapAction,
                               reCapIgnore);

            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"ReCaptcha Error: {e.Message}");
                context.Result = new RedirectResult(_reCaptcha.Option.Redirect ?? "/");
            }
        }

        protected virtual void CheckAttribute(string token,
                                              ReCaptchaAttribute classAtt,
                                              ReCaptchaAttribute actionAtt,
                                              ReCaptchaIgnoreAttribute ignoreAtt)
        {
            if (classAtt != null)
            {
                if (ignoreAtt == null)
                {
                    if (string.IsNullOrEmpty(token))
                        throw new InvalidOperationException("Token is empty!");

                    if (!_reCaptcha.IsValid(token))
                        throw new InvalidOperationException("Token invalid!");

                }
            }
            else if (actionAtt != null)
            {
                if (string.IsNullOrEmpty(token))
                    throw new InvalidOperationException("Token is empty!");

                if (!_reCaptcha.IsValid(token))
                    throw new InvalidOperationException("Token invalid!");
            }
        }
    }       
}
