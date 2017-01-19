// Kolla först på introvideon till denna uppgift
// Kopiera denna fil och skapa en ny fil "SingletonAnswer.cs" där din lösning finns. 
// "SingletonExpectedOutput.png" visar förväntat resultat 
// Självklart kommer du få andra tärningsslag, men huvudsaken är att TestMySingleton ger samma tärningskast alla tre gånger.

namespace AdvancedCsharp.DesignPatterns.Singleton
{
    using System;

    public class SingletonAssignement
    {
        // NORMAL CLASS

        class NormalClass
        {
            protected int _dice1;
            protected int _dice2;
            protected int _dice3;

            protected static Random _random = new Random();

            public NormalClass()
            {
                _dice1 = RollDice();
                _dice2 = RollDice();
                _dice3 = RollDice();
            }

            public string DiceRoll
            {
                get
                {
                    return $"{_dice1} {_dice2} {_dice3}";
                }
            }

            protected int RollDice()
            {
                return _random.Next(6) + 1;
            }
        }

        // SINGLETON

        class MySingleton : NormalClass
        {
            private static MySingleton _instance;
            private static object syncLock = new object();

            protected MySingleton()
            {
                _dice1 = RollDice();
                _dice2 = RollDice();
                _dice3 = RollDice();
            }

            public static MySingleton GetInstance()
            {
                // Den yttre if-satsen gör så man inte behöver låsa i onödan
                if (_instance == null)
                {
                    // Låset förhindrar att i en multitrådmiljö att flera instanser skapas
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MySingleton();
                        }
                    }
                }

                return _instance;
            }
        }

        private static void TestNormalClass()
        {
            Console.WriteLine("--- NormalClass ---");

            var x = new NormalClass();
            Console.WriteLine($"Diceroll x: {x.DiceRoll}");

            var y = new NormalClass();
            Console.WriteLine($"Diceroll y: {y.DiceRoll}");

            var z = new NormalClass();
            Console.WriteLine($"Diceroll z: {z.DiceRoll}");

            Console.WriteLine("");
        }

        private static void TestMySingleton()
        {
            Console.WriteLine("--- MySingleton ---");

            // Avkommentera koden nedan. Alla tre tärningskast ska ge samma resultat.

            var x = MySingleton.GetInstance();
            Console.WriteLine($"Diceroll x: {x.DiceRoll}");

            var y = MySingleton.GetInstance();
            Console.WriteLine($"Diceroll y: {y.DiceRoll}");

            var z = MySingleton.GetInstance();
            Console.WriteLine($"Diceroll z: {z.DiceRoll}");

            Console.WriteLine("");
        }

        public void Run()
        {
            // Detta ska inte kunna göras:  var my1 = new MySingleton();

            TestNormalClass();
            TestMySingleton();
        }

    }
}
