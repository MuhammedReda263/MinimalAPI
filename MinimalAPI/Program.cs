using MinimalAPI.Models;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Product> productsList = new List<Product>() { new Product { Id = 1, ProductName = "Ipad" }, new Product {Id=2, ProductName = "Iphone"} };

//GET /products
app.MapGet("/product", async (HttpContext context) => {
    var products = productsList;
    await context.Response.WriteAsync(JsonSerializer.Serialize(products));
   }
);

//GET /products/id
app.MapGet("/product/{id:int}", async (HttpContext context, int id) => {
    var product = productsList.FirstOrDefault(trmp=>trmp.Id==id);
    if (product == null)
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Incoorect product id");
        return;
    }
    await context.Response.WriteAsync(JsonSerializer.Serialize(product));
   }
);


//POST /products
app.MapPost("/product", async (HttpContext context,Product product) => {
    productsList.Add(product);
    await context.Response.WriteAsync("Product added successfully");
   }
);


app.Run();
