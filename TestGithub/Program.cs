using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TestGithub
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pizza> pizzas = new List<Pizza>
            {
                new Pizza
                {
                    Naam = "Pizza Margherita",
                    Onderdelen = new List<string> { "Tomatensaus", "Mozzarella" },
                    Prijs = 8m
                },

                new Pizza
                {
                    Naam = "Pizza Vegetariana",
                    Onderdelen = new List<string>
                            { "Tomatensaus", "Mozzarella", "Groenten" },
                    Prijs = 9.5m
                },

                new Pizza
                {
                    Naam = "Pizza Napoli",
                    Onderdelen = new List<string>
                            { "Tomatensaus", "Mozzarella",
                              "Ansjovis", "Kappers", "Olijven" },
                    Prijs = 10m
                }
            };

            //de pizzagegevens wegschrijven:
            //elke pizza wordt als één regel tekst weggeschreven
            string locatie = @"C:\Data\";
            StringBuilder pizzaRegel;
            try
            {
                using var schrijver = new StreamWriter(locatie + "Pizzas.txt");
                foreach (var pizza in pizzas)
                {
                    pizzaRegel = new StringBuilder();
                    pizzaRegel.Append($"{pizza.Naam}:");
                    pizzaRegel.Append($"{pizza.Onderdelen?.Count ?? 0}:");
                    pizzaRegel.Append(
                           $"{(pizza.Onderdelen != null ? string.Join(":", pizza.Onderdelen) : "")}:");
                    pizzaRegel.Append(pizza.Prijs);
                    schrijver.WriteLine(pizzaRegel); ;
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
