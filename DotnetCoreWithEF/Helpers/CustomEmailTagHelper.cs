using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotnetCoreWithEF.Helpers
{
    public class CustomEmailTagHelper:TagHelper
    {
        public string Email{ get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href",$"mailto:{Email}");
            output.Content.SetContent("My-Email:"+Email);
        }
    }
}
