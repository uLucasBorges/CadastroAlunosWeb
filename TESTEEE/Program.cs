using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
using Configuracao.Web.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using TESTEEE.Services;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();

var mvcviews = builder.Services.AddControllersWithViews()
              .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
              .AddNewtonsoftJson();

mvcviews.AddRazorRuntimeCompilation();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp";
});



string jwtSecret = "aikalikaaksiahgdgsa#@$!%$%!@";
var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecret));

var tokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidAudience = builder.Configuration["TokenConfiguration:Audience"],
    ValidIssuer = builder.Configuration["TokenConfiguration:Issuer"],
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(
    Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"])),
    ClockSkew = TimeSpan.Zero
};

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})

.AddCookie(options =>
{
    options.Cookie.Name = "token";
    options.ExpireTimeSpan = TimeSpan.FromHours(2);
    options.Events = new CookieAuthenticationEvents
    {
        OnRedirectToLogin = redirectContext =>
        {
            if (redirectContext.Request.Path.Value.StartsWith("/list"))
            {
                redirectContext.Response.Clear();
                redirectContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        },
        OnRedirectToAccessDenied = redirectContext =>
        {
            redirectContext.Response.StatusCode = 403;
            return Task.CompletedTask;
        }
    };
    options.SlidingExpiration = true;
    options.TicketDataFormat = new CustomJwtDataFormat(SecurityAlgorithms.HmacSha256, tokenValidationParameters, builder.Configuration);
})
.AddJwtBearer(configureOptions =>
{
    configureOptions.TokenValidationParameters = tokenValidationParameters;
    configureOptions.SecurityTokenValidators.Clear();
    configureOptions.SecurityTokenValidators.Add(new ClaimsSecurityTokenValidator());
    configureOptions.SaveToken = true;
});


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("School", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role,
         "Admin", "Member"
        );
    });
});





builder.Services.AddHttpClient<IAlunoService, AlunoService>(c => c.BaseAddress = new Uri(builder.Configuration["Services:SchoolAPI"]));

var app = builder.Build();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
app.UseAuthentication();
app.UseSpaStaticFiles();
app.UseMiddleware<CustomSpaAuthenticationBehaviourMiddleware>();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    if (app.Environment.IsDevelopment())
        spa.Options.SourcePath = "ClientApp/";
    else
        spa.Options.SourcePath = "dist";

    if (app.Environment.IsDevelopment())
    {
        spa.UseVueCli(npmScript: "serve");
    }

});


app.Run();
