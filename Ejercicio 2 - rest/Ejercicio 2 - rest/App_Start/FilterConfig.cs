﻿using System.Web;
using System.Web.Mvc;

namespace Ejercicio_2___rest
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
