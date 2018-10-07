using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Budget.Models.ViewModels;

namespace Budget.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "category-model")]
    public class CategoryLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public CategoryLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public CategoryInfo CategoryModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "category-url-")]
        public Dictionary<string, object> CategoryUrlValues { get; set; } = new Dictionary<string, object>();

        public bool CategoryClassesEnabled { get; set; }

        public string CategoryClass { get; set; }

        public string CategoryClassNormal { get; set; }

        public string CategoryClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            foreach(var category in CategoryModel.Categories)
            {
                TagBuilder tag = new TagBuilder("a");
                CategoryUrlValues["category"] = category.CategoryID;
                tag.Attributes["href"] = urlHelper.Action(PageAction, CategoryUrlValues);
                if (CategoryClassesEnabled)
                {
                    tag.AddCssClass(CategoryClass);
                    tag.AddCssClass(category.CategoryID == CategoryModel.CurrentCategory ? CategoryClassSelected : CategoryClassNormal);
                }
                tag.InnerHtml.Append(category.Name);
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result);
        }
    }
}

