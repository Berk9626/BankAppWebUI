using Berkmen.BankApp.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;

namespace Berkmen.BankApp.Web.TagHelpers
{
	[HtmlTargetElement("getAccountCount")]
	public class GetAccountCount : TagHelper
	{
		public int ApplicationUserId { get; set; }
		private readonly BankContext _context;
		public GetAccountCount(BankContext context)
		{
			_context = context;
		}
		public override void Process(TagHelperContext context, TagHelperOutput output) //process methodu overr.
		{
			var accountCount = _context.Accounts.Count(x=>x.ApplicationUserId == ApplicationUserId); //appuserıd'si bana gelen ıd olan userlraın Countını alacağım.
			var html = $"<span class='badge bg-danger'>{accountCount} </span>";

			output.Content.SetHtmlContent(html);
		}
	}
}
