using App.Infra.Integration.ReCaptcha.Models;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infra.Integration.ReCaptcha.Facades
{
    public class ReCaptchaFacade
    {
        readonly Core.ReCaptcha _context;

        public ReCaptchaFacade(Core.ReCaptcha reCaptcha)
        {
            _context = reCaptcha;
        }

        [Route("siteverify")]
        public ApiResponse Verify(ApiRequest request)
        {
            try
            {
                var result = _context.Host.GetRoute<ReCaptchaFacade>(nameof(Verify))
                                          .WithHeader("Content-Type", "application/json")
                                          .AllowAnyHttpStatus()
                                          .PostJsonAsync(request)
                                          .Result;

                var transResut = result.GetResponse<ApiResponse, object>();

                if (transResut is ApiResponse)
                    return transResut as ApiResponse;
            }
            catch(Exception e)
            {
                _context.Errors.Add(e.Message);
            }

            return default(ApiResponse);
        }
    }
}
