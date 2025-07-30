using MinimalAPI.Peliculas.Entities;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(conf =>
    {
        conf
            .WithOrigins(builder.Configuration.GetValue<string>("OrigenesPermitidos")!)
            .AllowAnyHeader()
            .AllowAnyMethod();
    });

    opt.AddPolicy("libre", conf =>
    {
        conf
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
//Services

var app = builder.Build();

//Middleware
app.UseCors();

app.MapGet("/", () => "Hello World!");


app.MapGet("/generos", () =>
{
    return new List<Genero>
    {
        new Genero { Id = 1, Nombre = "Acción" },
        new Genero { Id = 2, Nombre = "Comedia" },
        new Genero { Id = 3, Nombre = "Drama" },
    };
});

//Middleware


app.Run();
