using Microsoft.AspNetCore.Mvc;
using MyMinimalApi.modelli;

var builder = WebApplication.CreateBuilder(args);                                           
var app = builder.Build();

app.MapPost("/register", ([FromBody]RegistrationInformations registration) =>
{


    if ( string.IsNullOrEmpty(registration.Name) || string.IsNullOrEmpty(registration.PhoneNumber) || string.IsNullOrEmpty(registration.Email) || string.IsNullOrEmpty(registration.Password))
    {
                return Results.BadRequest("Please make sure you have filled all the fields.");
    }
    else
    { 
        using (var sw = new StreamWriter("Dati.txt", append: true))
        {
            sw.WriteLine($"Name: {registration.Name}," +
                $" Email: {registration.Email}, " +
                $"Phone: {registration.PhoneNumber}," +
                $" Password: {registration.Password}");
        }

        return Results.Ok(registration);

    }
   
    
});

app.Run();
