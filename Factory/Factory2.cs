
// http://www.dotnetperls.com/factory

namespace AdvancedCsharp.DesignPatterns.Factory
{
    using System;
    using System.Collections.Generic;

    public class Factory2
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

        // En statisk metod
        // Beroende på indata så returneras instanser av olika klasser
        // Fabriksklassen kan tillverka lite olika typer av objekt
        // Klasserna måste såklart tillhöra samma basklass eller samma interface

        static class PositionFactory
        {

            public static Position Create(string position)
            {

                switch (position)
                {
                    case "manager":
                        return new Manager();

                    case "clerk":
                        return new Clerk();

                    case "programmer":
                        return new Programmer();

                    default:
                        throw new Exception($"{position} är inte en tillåten position");
                }
            }
        }

        public void Run()
        {

            // Vi vill skapa objekt utifrån en lista av strängar 

            var positionStringList = new[] { "manager", "clerk", "programmer", "clerk", "programmer" };

            var list = new List<Position>();

            // Gå igenom listan av strängar och skapa listan av Position-objekt

            foreach (var position in positionStringList)
            {
                list.Add(PositionFactory.Create(position));
            }

            // Skriv ut den nya listan

            foreach (var p in list)
            {
                Console.WriteLine($"En instans av objektet {p.GetType().Name}");
            }

        }

    }
}
