using IMS.Plugins.EFCore.Data;
using IMS.UseCases.Interfaces.CategoryInterfaces;
using IMS.UseCases.Interfaces.UserAccountInterfaces;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.UsersAccountUseCases;
using IMS.UseCases.CategoryUseCases;
using IMS.WebApp.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using IMS.UseCases.Interfaces.SubcategoryInterfaces;
using IMS.UseCases.SubcategoryUseCases;
using IMS.UseCases.Interfaces.MaterialTypeInterfaces;
using IMS.UseCases.MaterialTypeUseCases;
using IMS.UseCases.Interfaces.MaterialNomenclatureInterfaces;
using IMS.UseCases.MaterialNomenclatureUseCases;
using IMS.UseCases.Interfaces.WriteOffInterfaces;
using IMS.UseCases.WriteOffUseCases;

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
// User account repository
builder.Services.AddTransient<IUserAccountRepository, UserAccountRepository>();
// Category repository
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
// Subcategory repository
builder.Services.AddTransient<ISubcategoryRepository, SubcategoryRepository>();
// Material Type repository
builder.Services.AddTransient<IMaterialTypeRepository, MaterialTypeRepository>();
// Material Nomenclature repository
builder.Services.AddTransient<IMaterialNomenclatureRepository, MaterialNomenclatureRepository>();
// WriteOff repository
builder.Services.AddTransient<IWriteOffRepository, WriteOffRepository>();

// 7) Добавляем сервисы
// user account services
builder.Services.AddTransient<IViewUsersAccountByNameUseCase, ViewUsersAccountByNameUseCase>();
builder.Services.AddTransient<IAddUserAccountUseCase, AddUserAccountUseCase>();
builder.Services.AddTransient<IViewUserAccountByIdUseCase, ViewUserAccountByIdUseCase>();
builder.Services.AddTransient<IEditUserAccountUseCase, EditUserAccountUseCase>();
builder.Services.AddTransient<IDeleteUserAccountUseCase, DeleteUserAccountUseCase>();
// category services
builder.Services.AddTransient<IViewCategoryByNameUseCase, ViewCategoryByNameUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IViewCategoryByIdUseCase, ViewCategoryByIdUseCase>();
// subcategory services
builder.Services.AddTransient<IAddSubcategoryUseCase, AddSubcategoryUseCase>();
builder.Services.AddTransient<IViewSubcategoryUseCase, ViewSubcategoryUseCase>();
builder.Services.AddTransient<IViewSubcategoryByIdUseCase, ViewSubcategoryByIdUseCase>();
builder.Services.AddTransient<IViewSubcategoryByIdCategoryUseCase, ViewSubcategoryByIdCategoryUseCase>();
// Material Type services
builder.Services.AddTransient<IViewMaterialTypeByNameUseCase, ViewMaterialTypeByNameUseCase>();
builder.Services.AddTransient<IAddMaterialTypeUseCase, AddMaterialTypeUseCase>();
builder.Services.AddTransient<IViewMaterialTypesByIdSubcategoryUseCase, ViewMaterialTypesByIdSubcategoryUseCase>();
// Material Nomenclature services
builder.Services.AddTransient<IAddMaterialNomenclatureUseCase, AddMaterialNomenclatureUseCase>();
builder.Services.AddTransient<IViewMaterialNomenclatureUseCase, ViewMaterialNomenclatureUseCase>();
// WriteOff services
builder.Services.AddTransient<IAddWriteOffUseCase, AddWriteOffUseCase>();
builder.Services.AddTransient<IViewWriteOffHistoryUseCase, ViewWriteOffHistoryUseCase>();

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
