using WebApp.Template.Models;

namespace WebApp.Template.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        public DefaultUserCardTemplate(AppUser appUser) : base(appUser)
        {
        }

        protected override string SetFooter()
        {
            return String.Empty;
        }

        protected override string SetPicture()
        {
            return $"<img class='card-img-top' src='/userpictures/blank.png'>";
        }
    }
}
