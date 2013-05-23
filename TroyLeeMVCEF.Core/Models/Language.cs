namespace TroyLeeMVCEF.Core.Models
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class Language
    {
        public string Url { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public RouteValueDictionary RouteValues { get; set; }
        public bool IsSelected { get; set; }

        public MvcHtmlString HtmlSafeUrl
        {
            get
            {
                return MvcHtmlString.Create(Url);
            }
        }
    }
}
