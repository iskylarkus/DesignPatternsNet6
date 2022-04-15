using WebApp.Observer.Models;

namespace WebApp.Observer.Observers
{
    public interface IUserObserver
    {
        void CreateUser(AppUser appUser);
    }
}
