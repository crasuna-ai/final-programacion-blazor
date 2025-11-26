using System.Text.Json.Serialization;

namespace BlazingPizza;

/// <summary>
///    /// Represents a customized burger as part of an order.
/// </summary>
public class Pizza
{
    public const int KidsSize = 60;
    public const int ClassicSize = 120;
    public const int SmashSize = 300;

    public static IReadOnlyList<PizzaSizeOption> SizeOptions { get; } = new List<PizzaSizeOption>
    {
        new("Kids", KidsSize),
        new("Classic", ClassicSize),
        new("Smash", SmashSize)
    };

    public const int DefaultSize = ClassicSize;
    public const int MinimumSize = KidsSize;
    public const int MaximumSize = SmashSize;

    public int Id { get; set; }

    public int OrderId { get; set; }

    public PizzaSpecial? Special { get; set; }

    public int SpecialId { get; set; }

    public int Size { get; set; }

    public List<PizzaTopping> Toppings { get; set; } = new();

    public static PizzaSizeOption? GetSizeOption(int size) => SizeOptions.FirstOrDefault(o => o.Size == size);

    public decimal GetBasePrice()
    {
        if(Special == null) throw new NullReferenceException($"{nameof(Special)} was null when calculating Base Price.");
        return ((decimal)Size / (decimal)DefaultSize) * Special.BasePrice;
    }

   public static string GetSizeLabel(int size)
    {
        var option = GetSizeOption(size);

        if (option is not null)
        {
            return $"{option.Name} ({option.Size}gr)";
        }

        return $"{size}gr";
    }

    public string GetSizeLabel() => GetSizeLabel(Size);


    public decimal GetTotalPrice()
    {
        if (Toppings.Any(t => t.Topping is null)) throw new NullReferenceException($"{nameof(Toppings)} contained null when calculating the Total Price.");
        return GetBasePrice() + Toppings.Sum(t => t.Topping!.Price);
    }

    public string GetFormattedTotalPrice()
    {
        return CurrencyFormatter.FormatCop(GetTotalPrice());
    }
}

public record PizzaSizeOption(string Name, int Size);

[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Serialization)]
[JsonSerializable(typeof(Pizza))]
public partial class PizzaContext : JsonSerializerContext { }