using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SystemBeauty.TagsHelper
{
    public class EmailTagHelper : TagHelper
    {
        public string Endereco { get; set; }
        public string Mensagem { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:" + Endereco);
            output.Content.SetContent(Mensagem);
        }
    }
}
