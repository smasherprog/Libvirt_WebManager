using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static partial class HtmlExtenstions
    {
        public static IHtmlString Spinner(this HtmlHelper helper, string id)
        {
            string htmlString = "<div id=\"" + id + "\" class=\"windows8_spinner pull-right\">";
            for (var i = 1; i <= 5; i++)
            {
                htmlString += "<div class=\"wBall\" id=\"wBall_" + i.ToString() + "\"><div class=\"wInnerBall\"></div></div>";
            }
            htmlString += "</div>";
            return new HtmlString(htmlString);
        }
        public static string Controller(this HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["controller"].ToString();
        }
        public static string Action(this HtmlHelper helper)
        {
            return helper.ViewContext.RouteData.Values["action"].ToString();
        }
        public static string Area(this HtmlHelper helper)
        {
            var area = helper.ViewContext.RouteData.DataTokens["area"];
            return area==null ? "" : area.ToString();
        }
    }
}