namespace AdvancedCsharp.DesignPatterns.Factory
{
    using System;
    using System.Collections.Generic;

    public class Factory2Bad
    {

        abstract class Position
        {
        }

        class Manager : Position
        {
        }

        class Clerk : Position
        {
        }

        class Programmer : Position
        {
        }


        public void Run()
        {
            // Vi vill skapa objekt utifrån en lista av strängar 

            var positionStringList = new[] { "manager", "clerk", "programmer", "clerk", "programmer" };

            var list = new List<Position>();

            // Gå igenom listan av strängar och skapa listan av Position-objekt

            foreach (var position in positionStringList)
            {
                // Koden kladdas ner av dessa switch-sats

                switch (position)
                {
                    case "manager":
                        list.Add(new Manager());
                        break;

                    case "clerk":
                        list.Add(new Clerk());
                        break;

                    case "programmer":
                        list.Add(new Programmer());
                        break;

                    default:
                        throw new Exception($"{position} är inte en tillåten position");

                }

            }

            // Skriv ut den nya listan

            foreach(var p in list)
            {
                Console.WriteLine($"En instans av objektet {p.GetType().Name}");
            }

        }

    }
}
