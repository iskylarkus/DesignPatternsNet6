using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Template.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
});

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<AppIdentityDbContext>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



using (var scope = app.Services.CreateScope())
{
    var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    identityDbContext.Database.Migrate();

    if (!userManager.Users.Any())
    {
        userManager.CreateAsync(new AppUser() { UserName = "user1", Email = "user1@hotmail.com", PictureUrl = "/userpictures/exists.jpg", Description = "Lorem Ipsum, dizgi ve bask? end?strisinde kullan?lan m?g?r metinlerdir. Lorem Ipsum, ad? bilinmeyen bir matbaac?n?n bir hurufat numune kitab? olu?turmak ?zere bir yaz? galerisini alarak kar??t?rd??? 1500'lerden beri end?stri standard? sahte metinler olarak kullan?lm??t?r." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "user2", Email = "user2@hotmail.com", PictureUrl = "/userpictures/exists.jpg", Description = "Lorem Ipsum, dizgi ve bask? end?strisinde kullan?lan m?g?r metinlerdir. Lorem Ipsum, ad? bilinmeyen bir matbaac?n?n bir hurufat numune kitab? olu?turmak ?zere bir yaz? galerisini alarak kar??t?rd??? 1500'lerden beri end?stri standard? sahte metinler olarak kullan?lm??t?r." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "user3", Email = "user3@hotmail.com", PictureUrl = "/userpictures/exists.jpg", Description = "Lorem Ipsum, dizgi ve bask? end?strisinde kullan?lan m?g?r metinlerdir. Lorem Ipsum, ad? bilinmeyen bir matbaac?n?n bir hurufat numune kitab? olu?turmak ?zere bir yaz? galerisini alarak kar??t?rd??? 1500'lerden beri end?stri standard? sahte metinler olarak kullan?lm??t?r." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "user4", Email = "user4@hotmail.com", PictureUrl = "/userpictures/exists.jpg", Description = "Lorem Ipsum, dizgi ve bask? end?strisinde kullan?lan m?g?r metinlerdir. Lorem Ipsum, ad? bilinmeyen bir matbaac?n?n bir hurufat numune kitab? olu?turmak ?zere bir yaz? galerisini alarak kar??t?rd??? 1500'lerden beri end?stri standard? sahte metinler olarak kullan?lm??t?r." }, "Password12*").Wait();
        userManager.CreateAsync(new AppUser() { UserName = "user5", Email = "user5@hotmail.com", PictureUrl = "/userpictures/exists.jpg", Description = "Lorem Ipsum, dizgi ve bask? end?strisinde kullan?lan m?g?r metinlerdir. Lorem Ipsum, ad? bilinmeyen bir matbaac?n?n bir hurufat numune kitab? olu?turmak ?zere bir yaz? galerisini alarak kar??t?rd??? 1500'lerden beri end?stri standard? sahte metinler olarak kullan?lm??t?r." }, "Password12*").Wait();
    }
}



app.Run();
