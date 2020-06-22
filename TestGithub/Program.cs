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
            string locatie = @"C:\Data\";

            List<Pizza> pizzas = new List<Pizza>();

            string pizzaRegel;
            string pizzaNaam;
            int aantalOnderdelen;
            List<string> pizzaOnderdelen;
            decimal prijs;

            //de pizzagegevens inlezen
            try
            {
                using var lezer = new StreamReader(locatie + "Pizzas.txt");
                while ((pizzaRegel = lezer.ReadLine()) != null)
                {
                    string[] gegevens = pizzaRegel.Split(new Char[] { ':' });

                    pizzaNaam = gegevens[0];
                    aantalOnderdelen = int.Parse(gegevens[1]);

                    pizzaOnderdelen = new List<string>();
                    for (var teller = 0; teller < aantalOnderdelen; teller++)
                    {
                        pizzaOnderdelen.Add(gegevens[teller + 2]);
                    }
                    prijs = decimal.Parse(gegevens[gegevens.Length - 1]);
                    //of
                    //prijs = decimal.Parse(gegevens[^1]);

                    pizzas.Add(
                        new Pizza
                        {
                            Naam = pizzaNaam,
                            Onderdelen = pizzaOnderdelen,
                            Prijs = prijs
                        });
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het lezen van het bestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //de pizzagegevens tonen
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine(pizza.ToString());
                foreach (string onderdeel in pizza.Onderdelen)
                {
                    Console.WriteLine(onderdeel);
                }
                Console.WriteLine();
            }


        }
    }
}
