using System.Globalization;

namespace BlazingPizza;

public static class CurrencyFormatter
{
    private static readonly CultureInfo CopCulture = new("es-CO");

    public static string FormatCop(decimal value) => value.ToString("C0", CopCulture);
}