namespace PizzaStore.DB;
public record Pizza
{
    public int Id { get; set; }
    public string? name { get; set; }
    public int phone { get; set; }

}
public class Pizzas
{
    private static List<Pizza> _Pizza = new List<Pizza>(){
        new Pizza{Id=3 ,name="Hallie Brewer",phone=12},
        new Pizza{Id=2 ,name="Harry Freeman",phone=38},
        new Pizza{Id=4, name="Alvin Alexander",phone=6}
    };
    public static List<Pizza> GetPizzas()
    {
        return _Pizza;
    }
    public static Pizza? GetPizza(int id)
    {
        return _Pizza.SingleOrDefault(pizza => pizza.Id == id);

    }
    public static Pizza CreatePizza(Pizza pizza)
    {
        _Pizza.Add(pizza);
        return pizza;
    }
    public static Pizza UpdatePizza(Pizza update)
    {
        _Pizza = _Pizza.Select(pizza =>
        {
            if (pizza.Id == update.Id)
            {
                pizza.name = update.name;
                pizza.phone = update.phone;

            }
            return pizza;
        }

).ToList();
        return update;
    }
    public static void RemovePizza(int id)
    {
        _Pizza = _Pizza.FindAll(pizza => pizza.Id != id).ToList();
    }
}