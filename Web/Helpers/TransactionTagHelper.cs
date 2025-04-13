using Domain.Enum.Transeation;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Web.Helpers
{
    public class TransactionTypeTagHelper : TagHelper
    {
        public TransactionType Type {get;set;}
        
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "td";

            switch (Type)
            {
                case TransactionType.Increase:
                    output.Content.SetContent("واریز");
                    break;
                case TransactionType.Decrease:
                    output.Content.SetContent("برداشت");
                    break;
                default:
                    output.Content.SetContent("نامشخص");
                    break;
            }

        }
    }
}