using GroqNet.ChatCompletions;
using GroqNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StyleMate.Data;
using StyleMate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Use only AddDefaultIdentity to configure Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.ConfigureApplicationCookie(options =>
{
    // Update the login path to point to your new custom path
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});

// Register other services
builder.Services.AddScoped<IClothingService, ClothingService>();
builder.Services.AddScoped<IClothingCombinationService, ClothingCombinationService>();
builder.Services.AddGroqClient(builder.Configuration.GetConnectionString("GROQ_API_KEY"), GroqModel.LLaMA3_8b);
builder.Services.AddHttpClient<IGroqService, GroqService>();
builder.Services.AddScoped<IGroqService, GroqService>();

// Configure DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
