using WebApp.Observer.Models;

namespace WebApp.Observer.Observers
{
    public class UserObserverWriteToConsole : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverWriteToConsole(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverWriteToConsole>>();

            logger.LogInformation($"user created : id = {appUser.Id}");
        }
    }
}
