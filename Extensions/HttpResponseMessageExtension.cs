using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

public static class HttpResponseMessageExtension
{
    public static object GetResponse<T,E>(this HttpResponseMessage http)
    {
        try
        {
            var httpResult = http.Content.ReadAsStringAsync().Result;

            switch (http.StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.Created:
                case HttpStatusCode.NoContent:
                    return JsonConvert.DeserializeObject<T>(httpResult);
                default:
                    return JsonConvert.DeserializeObject<E>(httpResult);
            }
        }
        catch
        {

        }

        return default(E);
    }
}
