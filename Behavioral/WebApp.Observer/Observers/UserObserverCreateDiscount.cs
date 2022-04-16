using WebApp.Observer.Models;

namespace WebApp.Observer.Observers
{
    public class UserObserverCreateDiscount : IUserObserver
    {
        private readonly IServiceProvider _serviceProvider;

        public UserObserverCreateDiscount(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public void UserCreated(AppUser appUser)
        {
            var logger = _serviceProvider.GetRequiredService<ILogger<UserObserverCreateDiscount>>();

            var context = _serviceProvider.GetRequiredService<AppIdentityDbContext>();

            context.Discounts.Add(new Discount { Rate = 10, UserId = appUser.Id });

            context.SaveChanges();

            logger.LogInformation($"discount created for user id : {appUser.Id}");
        }
    }
}
