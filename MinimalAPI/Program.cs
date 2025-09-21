using MinimalAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


List<Product> productsList = new List<Product>() { new Product { Id = 1, ProductName = "Ipad" }, new Product {Id=2, ProductName = "Iphone"} };

app.MapGet("/product", async (HttpContext context) => {
    var products = string.Join("\n" ,productsList.Select(temp=>temp.ToString()));
    await context.Response.WriteAsync(products);
   }
);

app.MapPost("/product", async (HttpContext context,Product product) => {
    productsList.Add(product);
    await context.Response.WriteAsync("Product added successfully");
   }
);


app.Run();
