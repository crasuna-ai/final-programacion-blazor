using System;
using System.Linq;

namespace BlazingPizza.Server;

public static class SeedData
{
    public static void Initialize(PizzaStoreContext db)
    {
        var toppings = new Topping[]
        {
            new Topping
            {
                Name = "Queso extra",
                Price = 2.50m,
            },
            new Topping
            {
                Name = "Tocino ahumado",
                Price = 2.99m,
            },
            new Topping
            {
                Name = "Jalapeños",
                Price = 1.20m,
            },
            new Topping
            {
                Name = "Champiñones",
                Price = 1.50m,
            },
            new Topping
            {
                Name = "Cebolla caramelizada",
                Price = 1.75m,
            },
            new Topping
            {
                Name = "Lechuga fresca",
                Price = 0.90m,
            },
            new Topping
            {
                Name = "Tomate en rodajas",
                Price = 0.90m,
            },
            new Topping
            {
                Name = "Aguacate",
                Price = 2.10m,
            },
            new Topping
            {
                Name = "Pepinillos",
                Price = 0.80m,
            },
            new Topping
            {
                Name = "Salsa BBQ",
                Price = 1.10m,
            },
            new Topping
            {
                Name = "Salsa de chipotle",
                Price = 1.30m,
            },
            new Topping
            {
                Name = "Crispy onions",
                Price = 1.60m,
            },
            new Topping
            {
                Name = "Tocino crujiente",
                Price = 1.95m,
            },
            new Topping
            {
                Name = "Huevo estrellado",
                Price = 2.40m,
            },
            new Topping
            {
                Name = "Queso suizo",
                Price = 1.80m,
            },
            new Topping
            {
                Name = "Queso cheddar",
                Price = 1.70m,
            },
            new Topping
            {
                Name = "Pepper jack",
                Price = 1.60m,
            },
            new Topping
            {
                Name = "Mostaza de dijón",
                Price = 0.95m,
            },
            new Topping
            {
                Name = "Tiras de pollo crujiente",
                Price = 3.75m,
            },
            new Topping
            {
                Name = "Pimientos asados",
                Price = 1.40m,
            },
            new Topping
            {
                Name = "Chips de papa",
                Price = 1.10m,
            },
            new Topping
            {
                Name = "Queso azul",
                Price = 2.20m,
            },
        };

        var specials = new PizzaSpecial[]
        {
            new PizzaSpecial
            {
                Name = "Classic Cheeseburger",
                Description = "Pan brioche tostado, carne a la parrilla y una lluvia de queso fundido.",
                BasePrice = 8.99m,
                ImageUrl = "img/burgers/classic-cheeseburger.svg",
            },
            new PizzaSpecial
            {
                Id = 2,
                Name = "BBQ Bacon Crunch",
                Description = "Tocino crujiente, salsa BBQ ahumada y aros de cebolla para un toque dulce-salado.",
                BasePrice = 11.50m,
                ImageUrl = "img/burgers/bbq-bacon.svg",
            },
            new PizzaSpecial
            {
                Id = 3,
                Name = "Jalapeño Fire Burger",
                Description = "Jalapeños frescos, queso pepper jack y chipotle para los amantes del picante.",
                BasePrice = 10.25m,
                ImageUrl = "img/burgers/jalapeno-fire.svg",
            },
            new PizzaSpecial
            {
                Id = 4,
                Name = "Double Smash Deluxe",
                Description = "Doble carne smash, queso cheddar y pepinillos con salsa especial de la casa.",
                BasePrice = 12.50m,
                ImageUrl = "img/burgers/double-smash.svg",
            },
            new PizzaSpecial
            {
                Id = 5,
                Name = "Mushroom Swiss Melt",
                Description = "Champiñones salteados, queso suizo y mayonesa de ajo suave.",
                BasePrice = 11.25m,
                ImageUrl = "img/burgers/mushroom-swiss.svg",
            },
            new PizzaSpecial
            {
                Id = 6,
                Name = "Veggie Garden Stack",
                Description = "Hamburguesa vegetariana a la parrilla con lechuga, tomate, pepinillos y pesto verde.",
                BasePrice = 10.75m,
                ImageUrl = "img/burgers/veggie-garden.svg",
            },
            new PizzaSpecial
            {
                Id = 7,
                Name = "Crispy Chicken Ranch",
                Description = "Filete de pollo crujiente, aderezo ranch y ensalada fresca.",
                BasePrice = 10.90m,
                ImageUrl = "img/burgers/crispy-chicken.svg",
            },
            new PizzaSpecial
            {
                Id = 8,
                Name = "Avocado Sunrise",
                Description = "Carne jugosa con láminas de aguacate, huevo estrellado y mayonesa de limón.",
                BasePrice = 11.35m,
                ImageUrl = "img/burgers/avocado-sunrise.svg",
            },
        };

        var expectedSpecialNames = specials.Select(s => s.Name).ToHashSet(StringComparer.OrdinalIgnoreCase);
        var currentSpecialNames = db.Specials.Select(s => s.Name).ToList();

        if (currentSpecialNames.Count == expectedSpecialNames.Count
            && currentSpecialNames.All(n => expectedSpecialNames.Contains(n)))
        {
            return;
        }

        db.Toppings.RemoveRange(db.Toppings);
        db.Specials.RemoveRange(db.Specials);
        db.SaveChanges();

        db.Toppings.AddRange(toppings);
        db.Specials.AddRange(specials);
        db.SaveChanges();
    }
}
