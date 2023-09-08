using SifreKasasiApp.Business.Extensions;
using SifreKasasiApp.Data.Extensions;
var builder = WebApplication.CreateBuilder(args);

var myPolicy = "myPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myPolicy, policy =>
    {
        policy.WithOrigins("https://localhost:7206")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(options => true)
        .AllowCredentials().Build();

    });
});



// Add services to the container.

builder.Services.LoadDataExtension(builder.Configuration);
builder.Services.LoadBusinessExtension();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(myPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
