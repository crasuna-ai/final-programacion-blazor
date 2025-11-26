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
                ImageUrl = "https://sevillasecreta.co/wp-content/uploads/2021/05/Mejores-hamburguesas-de-Sevilla-1-1024x822.jpg",
            },
            new PizzaSpecial
            {
                Id = 2,
                Name = "BBQ Bacon Crunch",
                Description = "Tocino crujiente, salsa BBQ ahumada y aros de cebolla para un toque dulce-salado.",
                BasePrice = 11.50m,
                ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/lilwaynegottan-674f8dac05106.jpg?resize=980:*",
            },
            new PizzaSpecial
            {
                Id = 3,
                Name = "Jalapeño Fire Burger",
                Description = "Jalapeños frescos, queso pepper jack y chipotle para los amantes del picante.",
                BasePrice = 10.25m,
                ImageUrl = "https://www.carniceriademadrid.es/wp-content/uploads/2022/09/smash-burger-que-es.jpg",
            },
            new PizzaSpecial
            {
                Id = 4,
                Name = "Double Smash Deluxe",
                Description = "Doble carne smash, queso cheddar y pepinillos con salsa especial de la casa.",
                BasePrice = 12.50m,
                ImageUrl = "https://www.radioimagina.cl/wp-content/uploads/2024/04/Que-son-las-smash-burgers-La-antigua-tecnica-de-hamburguesas-que-esta-tomando-tendencia-en-Santiago-jpg.webp",
            },
            new PizzaSpecial
            {
                Id = 5,
                Name = "Mushroom Swiss Melt",
                Description = "Champiñones salteados, queso suizo y mayonesa de ajo suave.",
                BasePrice = 11.25m,
                 ImageUrl = "https://cloudfront-us-east-1.images.arcpublishing.com/infobae/A4G2VEJ4B5EFDM5KIOYEQOJURE.jpg",
            },
            new PizzaSpecial
            {
                Id = 6,
                Name = "Veggie Garden Stack",
                Description = "Hamburguesa vegetariana a la parrilla con lechuga, tomate, pepinillos y pesto verde.",
                BasePrice = 10.75m,
                ImageUrl = "https://images.arla.com/recordid/6A59D52C-C439-4D39-959DC3E1B30A5117/picture.jpg?width=500&height=630&mode=max&format=webp",
            },
            new PizzaSpecial
            {
                Id = 7,
                Name = "Crispy Chicken Ranch",
                Description = "Filete de pollo crujiente, aderezo ranch y ensalada fresca.",
                BasePrice = 10.90m,
                ImageUrl = "https://templebarbcn.com/wp-content/uploads/2023/11/BACON_DOBLE-scaled.jpg",
            },
            new PizzaSpecial
            {
                Id = 8,
                Name = "Avocado Sunrise",
                Description = "Carne jugosa con láminas de aguacate, huevo estrellado y mayonesa de limón.",
                BasePrice = 11.35m,
                ImageUrl = "https://www.unileverfoodsolutions.com.co/dam/global-ufs/mcos/NOLA/calcmenu/recipes/col-recipies/fruco-tomate-cocineros/HAMBURGUESA%201200x709.png",
            },
        };

        var currentSpecials = db.Specials.ToList();
        var expectedByName = specials.ToDictionary(s => s.Name, StringComparer.OrdinalIgnoreCase);
        var shouldReseed = currentSpecials.Count != specials.Length;

        if (!shouldReseed)
        {
            foreach (var current in currentSpecials)
            {
                if (!expectedByName.TryGetValue(current.Name, out var expected)
                    || current.BasePrice != expected.BasePrice
                    || !string.Equals(current.Description, expected.Description, StringComparison.Ordinal)
                    || !string.Equals(current.ImageUrl, expected.ImageUrl, StringComparison.OrdinalIgnoreCase))
                {
                    shouldReseed = true;
                    break;
                }
            }
        }

        if (!shouldReseed)
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
