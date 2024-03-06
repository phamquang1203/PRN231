using _26_BuiVanToan_BusinessObject;
using _26_BuiVanToan_Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<eStoreContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("eStoreDb"))
); 
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options=>
    {
        options.Cookie.Name = "eStoreLoginCookie";
        options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
        options.Events = new CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            },
            OnRedirectToAccessDenied = redirectContext =>
            {
                redirectContext.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            },

        };
    });
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
     builder => builder.SetIsOriginAllowed(host => true)
                 .AllowAnyMethod()
                 .AllowAnyHeader()
                 .AllowCredentials());
});
//builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
//builder.Services.AddScoped<IBookAuthorRepostiory, BookAuthorRepository>();
//builder.Services.AddScoped<IBookRepository, BookRepository>();
//builder.Services.AddScoped<IP, PublisherRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IRoleRepos, RoleRepository>();
builder.Services.AddControllers().AddNewtonsoftJson
(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ssZ";
        options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
    }
)
    .AddOData(option => option.Select().Filter()
        .Count().OrderBy().Expand().SetMaxTop(100)
        .AddRouteComponents("odata", GetEdmModel()));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Author>("Authors");
    builder.EntitySet<Book>("Books");
    builder.EntitySet<BookAuthor>("BookAuthors");
    builder.EntitySet<Publisher>("Publishers");
    builder.EntitySet<Role>("Roles");
    builder.EntitySet<User>("Users");

    return builder.GetEdmModel();
}
app.UseHttpsRedirection();

app.UseRouting();
app .UseCors    ("CorsPolicy"); 
app.UseAuthorization();
app.UseAuthentication ();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
