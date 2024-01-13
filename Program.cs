using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Patricia_Adelina_web.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Filme");
    options.Conventions.AllowAnonymousToPage("/Filme/Index");
    options.Conventions.AllowAnonymousToPage("/Filme/Details");
    options.Conventions.AuthorizeFolder("/Vizionatori", "AdminPolicy");
});
builder.Services.AddDbContext<Patricia_Adelina_webContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Patricia_Adelina_webContext") ?? throw new InvalidOperationException("Connection string 'Patricia_Adelina_webContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("Patricia_Adelina_webContext") ?? throw new InvalidOperationException("Connection string 'Patricia_Adelina_webContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
