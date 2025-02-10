using BusinessLogicLayer;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Services;
using DataAccessLayer.Data;
using DataAccessLayer.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IQRCodeService, QRCodeService>();
builder.Services.AddScoped<IPdfService, PdfService>();

builder.Services.AddControllersWithViews();



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

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!dbContext.Users.Any())
    {
        var firstName = "Daberechukwu";
        var lastName = "Ibeakanma";
        var matricNumber = "20191153822";
        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            UserName = matricNumber,
            MatricNumber = matricNumber
        };

        var result = await userManager.CreateAsync(user, "Test@123");

        if (result.Succeeded)
        {
            Console.WriteLine("Admin user created successfully.");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                Console.WriteLine(error.Description);
            }
        }
    }
    
    if (!dbContext.Staff.Any())
    {
        dbContext.Staff.AddRange(
            new Staff { Id = "1", FullName = "Obinna Okafor", Expertise = "Networking", IsAvailable = true },
                new Staff { Id = "2", FullName = "Chidinma Eze", Expertise = "Software Development", IsAvailable = true },
                new Staff { Id = "3", FullName = "Chukwudi Nwankwo", Expertise = "Database Administration", IsAvailable = true },
                new Staff { Id = "4", FullName = "Ngozi Uche", Expertise = "Cybersecurity", IsAvailable = true },
                new Staff { Id = "5", FullName = "Emeka Obi", Expertise = "Hardware Repairs", IsAvailable = false },
                new Staff { Id = "6", FullName = "Adanna Nnamdi", Expertise = "Technical Support", IsAvailable = true },
                new Staff { Id = "7", FullName = "Ifeanyi Okeke", Expertise = "Networking", IsAvailable = false },
                new Staff { Id = "8", FullName = "Uchenna Madu", Expertise = "Software Development", IsAvailable = true },
                new Staff { Id = "9", FullName = "Nneka Chukwu", Expertise = "System Analysis", IsAvailable = true },
                new Staff { Id = "10", FullName = "Ikenna Nwosu", Expertise = "IT Consulting", IsAvailable = false }
        );
        dbContext.SaveChanges();
    }
    
}


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
