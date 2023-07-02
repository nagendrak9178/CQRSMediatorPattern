using CQRSMediatR_Sample.Behaviors;
using CQRSMediatR_Sample.DataStore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Register MediatR and provide default configuration to the constructor.
//Follow the url https://code-maze.com/cqrs-mediatr-in-aspnet-core/
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(Program).Assembly));

//Register Fakestore as singleton i.e same like temporary DB.
builder.Services.AddSingleton<FakeDataStore>();

//Register the MediatR BEHAVIOR (i.e.Logging Behaviour)
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviors<,>));


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
