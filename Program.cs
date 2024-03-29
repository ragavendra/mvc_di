using diLifeTimes_.Models;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITypeTransient, ClassTransient>();
builder.Services.AddScoped<ITypeScoped, ClassScoped>();
builder.Services.AddSingleton<ITypeSingleton, ClassSingleton>();
// builder.Services.AddTransient<AppClass>();

// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddKeycloakAuthentication(builder.Configuration);

builder.Services.AddAuthorization(o => o.AddPolicy("IsAdmin", b =>
{
    b.RequireRealmRoles("admin");
    // b.RequireResourceRoles("r-admin"); // stands for "resource admin"

    // resource roles are mapped to ASP.NET Core Identity roles
    // b.RequireRole("r-admin");
}));
builder.Services.AddKeycloakAuthorization(builder.Configuration);

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

/*
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
.RequireAuthorization();
app.MapGet("/secret2", () => "This is a different secret!")
    .RequireAuthorization(p => p.RequireClaim("scope", "myapi:secrets"));
*/
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
.RequireAuthorization("IsAdmin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
