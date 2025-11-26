namespace BlazingPizza;

/// <summary>
/// Represents a pre-configured burger template customers can order.
/// </summary>
public class PizzaSpecial
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal BasePrice { get; set; }

    public string Description { get; set; } = string.Empty;

    public string ImageUrl { get; set; } = "img/burgers/classic-cheeseburger.png";

    public string GetFormattedBasePrice() => BasePrice.ToString("0.00");
}