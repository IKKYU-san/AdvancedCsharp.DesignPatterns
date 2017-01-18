
namespace AdvancedCsharp.DesignPatterns.Singleton
{
    
    using System;
    using System.Collections.Generic;

    public class Singleton1
    {
        class LoadBalancer
        {
            private static LoadBalancer _instance;
            private List<string> _servers = new List<string>();
            private Random _random = new Random();

            private static object syncLock = new object();

            protected LoadBalancer()
            {
                // Konstruktorn kommer bara anropas en gång

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("LoadBalancer() körs");
                Console.ForegroundColor = ConsoleColor.White;

                _servers.Add("ServerI");
                _servers.Add("ServerII");
                _servers.Add("ServerIII");
                _servers.Add("ServerIV");
                _servers.Add("ServerV");
            }

            public static LoadBalancer GetLoadBalancer()
            {
                // Den yttre if-satsen gör så man inte behöver låsa i onödan
                if (_instance == null)
                {
                    // Låset förhindrar att i en multitrådmiljö att flera instanser skapas
                    lock (syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LoadBalancer();
                        }
                    }
                }

                return _instance;
            }

            public string Server
            {
                get
                {
                    int r = _random.Next(_servers.Count);
                    return _servers[r].ToString();
                }
            }
        }

        public void Run()
        {
            LoadBalancer b1 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b2 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b3 = LoadBalancer.GetLoadBalancer();
            LoadBalancer b4 = LoadBalancer.GetLoadBalancer();

            // Det är samma instanser
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Oj! b1, b2, b3, b4 är samma instans");
                Console.WriteLine("");
            }

        }
    }
}
