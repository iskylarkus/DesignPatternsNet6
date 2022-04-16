namespace WebApp.Template.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
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
