var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var proveedores = new List<Proveedores>();

app.MapGet("/proveedores", () =>
{
    return proveedores;
});

app.MapGet("/proveedores/{id}", (int id) =>
{
    var  proveedor = proveedores.FirstOrDefault(x => x.Id == id);
    return Results.Ok();
});

app.MapPost("/proveedores", (Proveedores Proveedores) =>
{
    proveedores.Add(Proveedores);
    return Results.Ok();
});

app.MapDelete("/proveedores/{id}", (int id) =>
{
    var existingProveedores = proveedores.FirstOrDefault(x => x.Id == id);
    if (existingProveedores != null)
    {
        proveedores.Remove(existingProveedores);
        return Results.NotFound();
    }
    else
    {
        return Results.NotFound();
    }
});

app.Run();

internal class Proveedores
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
