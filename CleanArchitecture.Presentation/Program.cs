
using Asp.Versioning;
using CleanArchitecture.Application;
using CleanArchitecture.Domain;
using CleanArchitecture.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region API Versioning
builder.Services.AddApiVersioning(config =>
{
    //Specify the default API Version as 1.0
    config.DefaultApiVersion = new ApiVersion(1, 0);
    //If the client hasn't specified the API Version in the request,use the default API Version Number
    config.AssumeDefaultVersionWhenUnspecified = true;
    //Advertise the API versions supported for the particular endpoint
    config.ReportApiVersions = true;
});
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ApplicationServiceRegistration.AddApplicationServices(builder.Services);
DomainServiceRegistration.AddDomainService(builder.Services);
PersistenceServiceRegistration.AddPersistenceService(builder.Services, builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }