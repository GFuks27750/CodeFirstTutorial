using CodeFirstTutorial.Contexts;
using CodeFirstTutorial.Exceptions;
using CodeFirstTutorial.RequestModels;
using CodeFirstTutorial.Services;
using CodeFirstTutorial.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataBaseContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapGet("api/account/{accountId:int}", async (int accountId,IAccountsService service) =>
{

    try
    {
        return Results.Ok(await service.GetAccountByIdAsync(accountId));
    }
    catch (NotFoundException e)
    {
        return Results.NotFound(e.Message);
    }
});
app.MapPost("/api/product", async (AddProductRequestModel productModel, IProductService service) =>
{

    var validator = new AddProductValidator();
    var validate = validator.Validate(productModel);

    if (!validate.IsValid)
    {
        return Results.BadRequest("Invalid data");
    }
    try
    {
        await service.AddProductAsync(productModel);
        return Results.Created($"/api/product/{productModel.ProductName}", productModel);
    }
    catch (BadRequestException e)
    {
        return Results.BadRequest(e.Message);
    }
});


app.Run();