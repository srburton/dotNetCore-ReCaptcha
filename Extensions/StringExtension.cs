using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

public static class StringExtension
{
    /// <summary>
    /// Responsavel por pegar o atributo Route de uma class 
    /// é util quando se faz classes de facade você pode por o atributo 
    /// Route e ficar mais declarativo para outro programador
    /// ex:
    ///  
    ///  [Route("/voucher/create?apikey={0}&algo={2}")]
    ///  public void Create(object obj);
    ///         
    ///  nameof(Create).GetRoute<VoucherPdvFacade>(1,"minhaurl");
    /// 
    /// result: 
    ///   
    ///  /voucher/create?apikey=1&algo=minhaurl
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="method"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string GetRoute<T>(this string @base, string method, params object[] data)
    {
        RouteAttribute route = typeof(T).GetMethod(method)
                                        .GetCustomAttribute<RouteAttribute>();

        string template = route.Template ?? string.Empty;

        for (int i = 0; i < data.Length; i++)
            template = template.Replace("{" + i + "}", data[i].ToString());

        return $"{@base}{template}";
    }

}

