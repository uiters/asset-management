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
    [HtmlTargetElement("script")]
    public class AbpZeroTemplateScriptSrcTagHelper : ScriptTagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output.Attributes["abp-ignore-src-modification"] != null && output.Attributes["abp-ignore-src-modification"].Value.ToString() == "true")
            {
                base.Process(context, output);
                return;
            }

            string srcKey;
            if (output.Attributes["abp-src"] != null)
            {
                srcKey = "abp-src";
            }
            else if (output.Attributes["src"] != null)
            {
                srcKey = "src";
            }
            else
            {
                base.Process(context, output);
                return;
            }

            if (output.Attributes[srcKey].Value.ToString().StartsWith("~"))
            {
                base.Process(context, output);
                return;
            }

            if (output.Attributes[srcKey].Value is HtmlString ||
                output.Attributes[srcKey].Value is string)
            {
                var href = output.Attributes[srcKey].Value.ToString();
                if (href.StartsWith("~"))
                {
                    return;
                }

                var basePath = ViewContext.HttpContext.Request.PathBase.HasValue
                    ? ViewContext.HttpContext.Request.PathBase.Value
                    : string.Empty;

                if (!HostingEnvironment.IsDevelopment() && !href.Contains(".min.js"))
                {
                    href = href.Replace(".js", ".min.js");
                }

                Src = basePath + href;
                context.AllAttributes.AddIfNotContains(new TagHelperAttribute("src", Src));
            }

            base.Process(context, output);
        }

        public AbpZeroTemplateScriptSrcTagHelper(
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