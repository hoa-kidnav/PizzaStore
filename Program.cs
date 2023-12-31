using Microsoft.OpenApi.Models;
using PizzaStore.DB;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = " Test Todo API", Description = "Keep track of your tasks", Version = "v1" });
});
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c =>
   {
     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
   });

app.MapGet("/", () => "Hello World!");


app.MapGet("/pizzas/{id}", (int id) => Pizzas.GetPizza(id));
app.MapGet("/pizzas", () => Pizzas.GetPizzas());
app.MapPost("/pizzas", (Pizza pizza) => Pizzas.CreatePizza(pizza));
app.MapPut("/pizzas", (Pizza pizza) => Pizzas.UpdatePizza(pizza));
app.MapDelete("/pizzas/{id}", (int id) => Pizzas.RemovePizza(id));
// app.UsCors('hello world!')
app.Run();
