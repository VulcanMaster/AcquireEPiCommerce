using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using System.Diagnostics;
using System.Web.Mvc;

namespace AcquireEPiCommerce.Web.Helpers
{
    public static class NavigationHelper
    {
        public static void RenderTopNavigation(this HtmlHelper html,
            PageReference rootLink = null,
            ContentReference contentLink = null,
            bool includeRoot = true,
            IContentLoader contentLoader = null
            )
        {

            rootLink = rootLink ?? ContentReference.StartPage;

            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();

            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();

            var topLevelPages = contentLoader.GetChildren<PageData>(rootLink);
            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

            var writer = html.ViewContext.Writer;

            writer.WriteLine("");
            writer.WriteLine("<nav class='navbar navbar-expand-lg navbar-light bg-light'>");
            writer.WriteLine("<a class='navbar-brand' href='/'>STOCK</a>");
            writer.WriteLine("<button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarSupportedContent' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>");
            writer.WriteLine("<span class='navbar-toggler-icon'></span>");
            writer.WriteLine("</button>");

            writer.WriteLine("<div class='collapse navbar-collapse' id='navbarSupportedContent'>");
            writer.WriteLine("<ul class='navbar-nav mr-auto'>");

            if (includeRoot)
            {
                writer.WriteLine("<li class='nav-item'>");
                writer.WriteLine("<a class='nav-link' href='#'>" + contentLoader.Get<PageData>(rootLink).Name + "<span class='sr-only'>(current)</span></a>");
                writer.WriteLine("</li>");
            }

            foreach (var topLevelPage in topLevelPages)
            {
                writer.WriteLine("<li class='nav-item'>");
                writer.WriteLine("<a class='nav-link' href='" + urlResolver.GetUrl(topLevelPage) + "'>" + topLevelPage.Name + "</a>");
                writer.WriteLine("</li>");
            }
            writer.WriteLine("</ul>");
            writer.WriteLine("</div>");
            writer.WriteLine("</nav>");
        }
    }
}