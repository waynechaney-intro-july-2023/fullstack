using Marten;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers() // Microsoft stuff for creating instances of controllers, etc.
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); // this is Microsoft stuff for making the endpoints visible to tools.
builder.Services.AddSwaggerGen(); // the service that uses the one above to translate to OpenAPI

var dataConnectionString = builder.Configuration.GetConnectionString("todos") ?? throw new Exception("Need a database connection string");
Console.WriteLine($"Using the connection string {dataConnectionString}");
builder.Services.AddMarten(options =>
{
    options.Connection(dataConnectionString);



    options.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All; // good for development, it creates everything.
});
// everything above this line is configuring "Services" in our application.
var app = builder.Build();
// this is configuring the "middleware" - this is code that will see the incoming HTTP request
// and make a response.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // This is the OpenApi this generates the documentation which is a JSON file (called a "Swagger" file)
    app.UseSwaggerUI(); // adds middleware that lets you interact with that documentation.
}

app.UseAuthorization();

app.MapControllers(); // The Api, during startup, is going to look at all our Controller clases, read those attributes
// and create a "route table" - like phone list.



app.Run(); // start the Kestrel web server and listen for requests.