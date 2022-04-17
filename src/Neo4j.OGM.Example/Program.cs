using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Neo4j.OGM.Example.Data;
using Neo4j.OGM;
using Neo4j.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register Neo4j OGM serivces
builder.Services.AddNeo4jOGMFactory(
    builder.Configuration.GetConnectionString("Neo4jConnection"),
    AuthTokens.Basic(builder.Configuration.GetConnectionString("Neo4jUser"),
                     builder.Configuration.GetConnectionString("Neo4jPassword")),
    typeof(Person).Assembly
);

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
