
namespace AdvancedCsharp.DesignPatterns.Factory
{
    using System;

    class FactoryAssignement
    {
        public abstract class Link
        {
            public string Url { get; set; }
        }

        class InternalLink : Link
        {
        }

        class ExternalLink : Link
        {
        }

        public void Run()
        {

            var linkList = new []{ "aaa/bbb.html", "http://gooogle.com", "http://www.happybits.se"};

            foreach (var url in linkList)
            {
                Link link;

                if (url.StartsWith("http://"))
                {
                    link = new ExternalLink { Url = url };
                }
                else
                {
                    link = new InternalLink { Url = url };
                }

                Console.WriteLine($"Länken är av typen {link.GetType().Name} och har addressen {link.Url}");
            }
        }

    }


}
