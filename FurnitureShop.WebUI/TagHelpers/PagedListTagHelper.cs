using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Reflection.Emit;

namespace FurnitureShop.WebUI.TagHelpers
{
    [HtmlTargetElement("pager", Attributes = TotalCountAttribute)]
    [HtmlTargetElement("pager", Attributes = IndexPageAttribute)]
    [HtmlTargetElement("pager", Attributes = TakeAttrubite)]
    [HtmlTargetElement("pager", Attributes = PagerListActionAttributeName)]
    [HtmlTargetElement("pager", Attributes = HostAttributeName)]
    [HtmlTargetElement("pager", Attributes = FragmentAttributeName)]
    [HtmlTargetElement("pager", Attributes = PagedListRouteAttributeName)]
    [HtmlTargetElement("pager", Attributes = PagedListRouteDataAttributeName)]
    [HtmlTargetElement("pager", Attributes = ProtocolAttributeName)]
    [HtmlTargetElement("pager", Attributes = ControllerAttributeName)]
    public class PagedListTagHelper :TagHelper
    {
        private const string TotalCountAttribute = "asp-paged-total-element";
        private const string IndexPageAttribute = "asp-paged-index";
        private const string TakeAttrubite = "asp-paged-take";
        private readonly IHtmlGenerator _htmlGenerator;

        [HtmlAttributeName(TotalCountAttribute)]
        public int TotalCountElement { get; set; }

        [HtmlAttributeName(IndexPageAttribute)]
        public int IndexPage { get; set; }

        [HtmlAttributeName(TakeAttrubite)]
        public int TakeItemPerPage { get; set; }

        public PagedListTagHelper(IHtmlGenerator htmlGenerator)
        {
            _htmlGenerator = htmlGenerator;
        }

        #region Properties for Private calculation


        private string DisableCss => "disabled";

        private string PageLinkCss => "page-link";

        private string RootTagCss => "pagination";

        private string ActiveTagCss => "active";

        private string PageItemCss => "page-item";

        #endregion
        #region Properties for Generator
        private readonly IDictionary<string, string> _routeValues = new Dictionary<string, string>();
        private const string PagerListActionAttributeName = "asp-paged-list-url";
        private const string HostAttributeName = "asp-host";
        private const string FragmentAttributeName = "asp-fragment";
        private const string PagedListRouteAttributeName = "asp-route-parameter";
        private const string PagedListRouteDataAttributeName = "asp-route-data";
        private const string ProtocolAttributeName = "asp-protocol";
        private const string ControllerAttributeName = "asp-controller";

        [ViewContext]
        public ViewContext? ViewContext { get; set; }

        [HtmlAttributeName(PagerListActionAttributeName)]
        public string? ActionName { get; set; }

        [HtmlAttributeName(PagedListRouteAttributeName)]
        public string RouteParameter { get; set; } = null!;

        [HtmlAttributeName(PagedListRouteDataAttributeName)]
        public object? RouteParameters { get; set; }

        /// <summary>
        /// The URL fragment name.
        /// </summary>
        [HtmlAttributeName(FragmentAttributeName)]
        public string? Fragment { get; set; }

        /// <summary>
        /// The protocol for the URL, such as &quot;http&quot; or &quot;https&quot;.
        /// </summary>
        [HtmlAttributeName(ProtocolAttributeName)]
        public string? Protocol { get; set; }

        /// <summary>
        /// The host name.
        /// </summary>
        [HtmlAttributeName(HostAttributeName)]
        public string? Host { get; set; }

        /// <summary>
        /// The name of the controller.
        /// </summary>
        /// <remarks>Must be <c>null</c> if <see cref="Route"/> is non-<c>null</c>.</remarks>
        [HtmlAttributeName(ControllerAttributeName)]
        public string Controller { get; set; } = null!;

        #endregion
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (TotalCountElement <= TakeItemPerPage)
            {
                return;
            }


            var ul = new TagBuilder("ul");
            ul.AddCssClass(RootTagCss);

            for (int i = 0; i <=TotalCountElement/TakeItemPerPage; i++)
            {
                var li = new TagBuilder("li");
                li.AddCssClass(PageItemCss);
               
                if (i == IndexPage)
                {
                    li.AddCssClass(ActiveTagCss);
                }
                var a = GenerateLink((1 + i).ToString(),  i); 
                li.InnerHtml.AppendHtml(a);
                ul.InnerHtml.AppendHtml(li);
            }


            output.Content.AppendHtml(ul);


            base.Process(context, output);
        }

        private TagBuilder GenerateLink(string linkText, int routeValue)
        {
            var routeValues = new RouteValueDictionary(_routeValues) { { RouteParameter, (routeValue*TakeItemPerPage).ToString() } };
            if (RouteParameters != null)
            {
                var values = RouteParameters.GetType().GetProperties();
                if (values.Any())
                {
                    foreach (var propertyInfo in values)
                    {
                        routeValues.Add(propertyInfo.Name, propertyInfo.GetValue(RouteParameters));
                    }
                }
            }

            return _htmlGenerator.GenerateActionLink(
                viewContext: ViewContext,
                actionName: ActionName,
                controllerName: Controller,
                routeValues: routeValues,
                hostname: Host,
                linkText: linkText,
                fragment: Fragment,
                htmlAttributes: new { @class = PageLinkCss },
                protocol: Protocol);
        }
    }
}
