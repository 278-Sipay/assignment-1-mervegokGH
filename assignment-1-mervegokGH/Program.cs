using assignment_1_mervegokGH.Model;
using assignment_1_mervegokGH.Validator;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//PersonValidator class as the implementation for the IValidator<Person> interface in the dependency injection container, allowing the validator to be injected wherever an IValidator<Person> dependency is required.
builder.Services.AddTransient<IValidator<Person>, PersonValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
