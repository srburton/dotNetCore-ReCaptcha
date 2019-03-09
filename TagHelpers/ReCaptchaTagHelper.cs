using App.Infra.Integration.ReCaptcha.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

public static class ReCaptchaTagHelper
{
    public static IHtmlContent ReCaptcha(this IHtmlHelper html)
    {
        StringBuilder builder = new StringBuilder();

        builder.Append($"<script src='https://www.google.com/recaptcha/api.js?render={ReCaptchaPublicConfig.PublicKey}'></script>");
        builder.Append("<script> function sc(e,t,i){var o='';if(i){var n=new Date;n.setTime(n.getTime()+i*60*1e3),o='; expires='+n.toUTCString()}document.cookie=e+'='+(t||'')+o+'; path=/'}</script>");
        builder.Append("<script>grecaptcha.ready(function () {grecaptcha.execute('" + ReCaptchaPublicConfig.PublicKey + "',{ action: 'index' }).then(function (token) {sc('g-recaptcha',token,10);});});</script>");

        return new HtmlString(builder.ToString());
    }
}
