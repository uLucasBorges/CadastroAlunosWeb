using System;
using ApiCadastroAlunos.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TESTEEE.Services;
using VueCliMiddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "ClientApp";
});

builder.Services.AddHttpClient<IAlunoService, AlunoService>(c => c.BaseAddress = new Uri(builder.Configuration["Services:SchoolAPI"]));

var app = builder.Build();

app.UseRouting();
app.UseSpaStaticFiles();
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
