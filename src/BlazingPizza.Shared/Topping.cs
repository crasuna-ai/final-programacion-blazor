namespace BlazingPizza;

public class Topping
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string GetFormattedPrice() => CurrencyFormatter.FormatCop(Price);


}