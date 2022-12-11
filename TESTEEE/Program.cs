using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiCadastroAlunos.Core.Interfaces;
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


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp";
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
app.UseSpaStaticFiles();

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
