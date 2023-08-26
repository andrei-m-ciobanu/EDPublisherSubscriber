using EmergencyDepartment.Application.Ports.Primary;
using EmergencyDepartment.Application.Ports.Secondary.Persistance;
using EmergencyDepartment.Application.Ports.Secondary.Publisher;
using EmergencyDepartment.Application.Services;
using EmergencyDepartment.Application.Services.TriageAlgorithms;
using EmergencyDepartment.PrimaryAdapter.Rest.Middleware;
using EmergencyDepartment.SecondaryAdapter.Persistence;
using EmergencyDepartment.SecondaryAdapter.Publisher;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmergencyDepartmentDbContext>(
    opt => opt.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly(typeof(EmergencyDepartmentDbContext).Assembly.FullName)));

builder.Services.AddControllers();

builder.Services.AddScoped<IPatientPort, PatientAdapter>();
builder.Services.AddScoped<IManchesterTriageSepsisAlgorithm, ManchesterTriageSepsisAlgorithm>();
builder.Services.AddScoped<IPatientService, PatientService>();

builder.Services.AddSingleton<IConnectionFactory>(serviceProvider => new ConnectionFactory 
    { 
        AutomaticRecoveryEnabled = true,
        HostName = "localhost"
    });
builder.Services.AddSingleton<IMessageQueuePublisher, MessageQueuePublisher>();
builder.Services.AddScoped<IPublisherPort, PublisherAdapter>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
