namespace TroyLeeMVCEF.Core.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Routing;

    using TroyLeeMVCEF.Core.Models;

    public static class CommonFunctions
    {
        #region Generate Random String
        public static string GenerateRandomString(int length = 6)
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (int i = 0; i < length; i++)
            {
                char ch = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random.NextDouble() + 75)));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        #endregion

        #region Switch Language
        public static Language LanguageUrl(this HtmlHelper helper, string cultureName,
            string languageRouteName = "lang", bool strictSelected = false)
        {
            // set the input language to lower
            cultureName = cultureName.ToLower();
            // retrieve the route values from the view context
            var routeValues = new RouteValueDictionary(helper.ViewContext.RouteData.Values);
            // copy the query strings into the route values to generate the link
            var queryString = helper.ViewContext.HttpContext.Request.QueryString;
            foreach (string key in queryString)
            {
                if (queryString[key] != null && !string.IsNullOrWhiteSpace(key))
                {
                    if (routeValues.ContainsKey(key))
                    {
                        routeValues[key] = queryString[key];
                    }
                    else
                    {
                        routeValues.Add(key, queryString[key]);
                    }
                }
            }
            var actionName = routeValues["action"].ToString();
            var controllerName = routeValues["controller"].ToString();
            // set the language into route values
            routeValues[languageRouteName] = cultureName;
            // generate the language specify url
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext, helper.RouteCollection);
            var url = urlHelper.RouteUrl("Localization", routeValues);
            // check whether the current thread ui culture is this language
            var current_lang_name = Thread.CurrentThread.CurrentUICulture.Name.ToLower();
            var isSelected = strictSelected ?
                current_lang_name == cultureName :
                current_lang_name.StartsWith(cultureName);
            return new Language
                {
                Url = url,
                ActionName = actionName,
                ControllerName = controllerName,
                RouteValues = routeValues,
                IsSelected = isSelected
            };
        }

        public static MvcHtmlString LanguageSelectorLink(this HtmlHelper helper,
            string cultureName, string imageUrl,
            IDictionary<string, object> htmlAttributes, string languageRouteName = "lang", bool strictSelected = false)
        {
            var language = helper.LanguageUrl(cultureName, languageRouteName, strictSelected);
            var tagBuilder = new TagBuilder("img");
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var url = language.Url;
            var imgUrl = urlHelper.Content(imageUrl);
            var image = "";
            var html = new StringBuilder();

            // build the image tag.
            tagBuilder.MergeAttribute("src", imgUrl);
            image = tagBuilder.ToString(TagRenderMode.SelfClosing);

            html.Append("<a href=\"");
            html.Append(url);
            html.Append("\">");
            html.Append(image);
            html.Append("</a>");

            return MvcHtmlString.Create(html.ToString());
        }
        #endregion

        #region Password
        public static string MD5EncryptPassword(string password)
        {
            var x = new MD5CryptoServiceProvider();

            byte[] bs = Encoding.UTF8.GetBytes(password);

            bs = x.ComputeHash(bs);

            var sb = new StringBuilder();

            foreach (byte b in bs)
            {

                sb.Append(b.ToString("x2").ToUpper());

            }

            return sb.ToString();
        }
        internal static string GenerateRandomString()
        {
            var builder = new StringBuilder();
            var random = new Random();
            for (var i = 0; i < 6; i++)
            {
                var ch = Convert.ToChar(Convert.ToInt32(Math.Floor(25 * random.NextDouble() + 75)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        public static string ResetPassword()
        {
            var newPass = GenerateRandomString();
            return newPass;
        }
        #endregion

        #region Send Email

        #endregion
    }
}
