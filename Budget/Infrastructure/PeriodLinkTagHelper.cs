using Budget.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace Budget.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "period-model")]
    public class PeriodLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public PeriodLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PeriodInfo PeriodModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "period-url-")]
        public Dictionary<string, object> PeriodUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PeriodClassesEnabled { get; set; }

        public string PeriodClass { get; set; }

        public string PeriodClassNormal { get; set; }

        public string PeriodClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");

            TagBuilder tag = new TagBuilder("a");
            PeriodUrlValues["period"] = PeriodModel.PeriodType;
            PeriodUrlValues["periodNum"] = PeriodModel.CurrentPeriod - 1;
            tag.Attributes["href"] = urlHelper.Action(PageAction, PeriodUrlValues);            
            tag.InnerHtml.Append(" < ");
            result.InnerHtml.AppendHtml(tag);

            tag = new TagBuilder("span");
            tag.InnerHtml.Append(PeriodModel.Date);
            result.InnerHtml.AppendHtml(tag);

            tag = new TagBuilder("a");
            PeriodUrlValues["period"] = PeriodModel.PeriodType;
            PeriodUrlValues["periodNum"] = PeriodModel.CurrentPeriod + 1;
            tag.Attributes["href"] = urlHelper.Action(PageAction, PeriodUrlValues);
            tag.InnerHtml.Append(" > ");
            result.InnerHtml.AppendHtml(tag);

            output.Content.AppendHtml(result);
        }
    }
}