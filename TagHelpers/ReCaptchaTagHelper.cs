using App.Infra.Integration.ReCaptcha.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

public static class ReCaptchaTagHelper
{
    public static IHtmlContent ReCaptcha(this IHtmlHelper html)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append($"<input readonly hidden name=g-recaptcha hidden readonly data-sitekey='{ReCaptchaPublicConfig.PublicKey}' />");
        builder.Append($"<script src='https://www.google.com/recaptcha/api.js?render={ReCaptchaPublicConfig.PublicKey}'></script>");
        builder.Append("<script>grecaptcha.ready(function () {grecaptcha.execute('" + ReCaptchaPublicConfig.PublicKey + "',{ action: 'index' }).then(function (token) { document.querySelector('input[name=g-recaptcha]').value = token; });});</script>");

        return new HtmlString(builder.ToString());
    }
}
