
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

        static class Factory{
            public static Link Create(string url) {
                if (url.StartsWith("http://"))
                {
                    return new ExternalLink { Url = url };
                }
                else
                {
                    return new InternalLink { Url = url };
                }
            }
        }

        public void Run()
        {

            var linkList = new []{ "aaa/bbb.html", "http://gooogle.com", "http://www.happybits.se"};

            foreach (var url in linkList)
            {
                Link link = Factory.Create(url);
                Console.WriteLine($"Länken är av typen {link.GetType().Name} och har addressen {link.Url}");
            }
        }
    }


}
