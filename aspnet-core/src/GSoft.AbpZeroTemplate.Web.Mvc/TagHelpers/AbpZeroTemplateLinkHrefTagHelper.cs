using System.Text.Encodings.Web;
using Abp.Collections.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Caching.Memory;

namespace GSoft.AbpZeroTemplate.Web.TagHelpers
{
    [HtmlTargetElement("link")]
    public class AbpZeroTemplateLinkHrefTagHelper : LinkTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.Attributes["abp-ignore-href-modification"] != null && output.Attributes["abp-ignore-href-modification"].Value.ToString() == "true")
            {
                base.Process(context, output);
                return;
            }

            string hrefKey;
            if (output.Attributes["abp-href"] != null)
            {
                hrefKey = "abp-href";
            }
            else if (output.Attributes["href"] != null)
            {
                hrefKey = "href";
            }
            else
            {
                base.Process(context, output);
                return;
            }

            if (output.Attributes[hrefKey].Value is HtmlString ||
                output.Attributes[hrefKey].Value is string)
            {
                var href = output.Attributes[hrefKey].Value.ToString();
                if (href.StartsWith("~"))
                {
                    base.Process(context, output);
                    return;
                }

                var basePath = ViewContext.HttpContext.Request.PathBase.HasValue
                    ? ViewContext.HttpContext.Request.PathBase.Value
                    : string.Empty;

                if (!HostingEnvironment.IsDevelopment() && !href.Contains(".min.css"))
                {
                    href = href.Replace(".css", ".min.css");
                }

                Href = basePath + href;
                context.AllAttributes.AddIfNotContains(new TagHelperAttribute("href", Href));
            }

            base.Process(context, output);
        }

        public AbpZeroTemplateLinkHrefTagHelper(
            IHostingEnvironment hostingEnvironment,
            IMemoryCache cache,
            HtmlEncoder htmlEncoder,
            JavaScriptEncoder javaScriptEncoder,
            IUrlHelperFactory urlHelperFactory
        ) : base(hostingEnvironment, cache, htmlEncoder, javaScriptEncoder, urlHelperFactory)
        {
        }
    }
}