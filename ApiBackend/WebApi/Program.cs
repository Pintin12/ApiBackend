using WebApi;
using Infrastructure;
using Application;
using WebApi.Middlewares;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();


app.UseMiddleware<GloblalExceptionHandlingMiddleware>();

app.Run();
