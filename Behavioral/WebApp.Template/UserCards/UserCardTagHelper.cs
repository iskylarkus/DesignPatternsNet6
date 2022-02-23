using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Template.Models;

namespace WebApp.Template.UserCards
{
    public class UserCardTagHelper:TagHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppUser AppUser { get; set; }

        public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new PrimeUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);

            output.Content.SetHtmlContent(userCardTemplate.Build());
        }

        public override Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new PrimeUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);

            output.Content.SetHtmlContent(userCardTemplate.Build());

            return Task.CompletedTask;
        }
    }
}
