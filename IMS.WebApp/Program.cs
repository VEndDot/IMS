using IMS.Plugins.EFCore.Data;
using IMS.UseCases.Interfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.UsersAccountUseCases;
using IMS.WebApp.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();




// 1) Добавил сервис аутентификацию. Для механизма аутентификации использую файлы cookie 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => 
    {
        options.Cookie.Name = "auth_token";               // имя куки
        options.LoginPath = "/login";                     // страница для входа в систему
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30); // время жизни куки
        options.AccessDeniedPath = "/access-denied";      // Страница для несанкционированного доступа
    });




// 3) внедряю службу авторизации
builder.Services.AddAuthentication();
// 4) вводится важная служба использующая каскадные состояния авторизации (ответственна за эффективную передачу состояния аутентификации по всему приложению)
builder.Services.AddCascadingAuthenticationState();
// 5) Включаем интеграцию с базой данных в наше приложение что позволит извлекать данные пользователей
builder.Services.AddDbContext<IMSDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DbConnection"),
        b => b.MigrationsAssembly("IMS.Plugins.EFCore")
        );
});

// 6) Добавляем репозитории
builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>();
// 7) Добавляем сервисы
builder.Services.AddTransient<IViewUsersAccountByNameUseCase, ViewUsersAccountByNameUseCase>();
builder.Services.AddTransient<IAddUserAccountUseCase, AddUserAccountUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();



app.UseStaticFiles();
app.UseAntiforgery();
// 2) Дабавление авторизации и аутентификации
app.UseAuthentication();
app.UseAuthorization();




app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
