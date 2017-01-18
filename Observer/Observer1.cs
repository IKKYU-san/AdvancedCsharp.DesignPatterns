
namespace AdvancedCsharp.DesignPatterns.Observer
{
    
    using System;
    using System.Collections.Generic;

    public class Observer1
    {
        public void Run()
        {
            // Skapa ibm-aktien
            IBM ibm = new IBM("IBM", 120.00);

            // En extra investor
            var myInvestor = new Investor("happybits");

            // Vi lägger till investerare
            ibm.Attach(new Investor("Sorros"));
            ibm.Attach(new Investor("Berkshire"));
            ibm.Attach(myInvestor);

            // När priset ändras så blir investorerna meddelade
            ibm.Price = 120.10;
            ibm.Price = 121.00;

            // Nu tar vi bort en investor och fortsätter ändra priset
            ibm.Detach(myInvestor);
            ibm.Price = 120.50;
            ibm.Price = 120.75;
        }

        // Stock är den klass som blir observerad
        abstract class Stock
        {
            private string _symbol;
            private double _price;

            // aktien håller reda på sina investorer
            private List<IInvestor> _investors = new List<IInvestor>(); 

            public Stock(string symbol, double price)
            {
                this._symbol = symbol;
                this._price = price;
            }

            public void Attach(IInvestor investor)
            {
                // Lägg till investorn i vår lista
                _investors.Add(investor);
            }

            public void Detach(IInvestor investor)
            {
                _investors.Remove(investor);
            }

            public void Notify()
            {
                // Alla investorer som är kopplade till aktien får reda på att något har hänt med aktiekursen

                // Eller enklare: _investors.ForEach(i => i.Update(this));

                foreach (IInvestor investor in _investors)
                {
                    investor.Update(this);
                }

                Console.WriteLine("");
            }

            public double Price
            {
                get { return _price; }
                set
                {
                    if (_price != value)
                    {
                        _price = value;

                        // När priset på en aktie ändras för en aktie så körs denna metod
                        Notify();
                    }
                }
            }

            public string Symbol
            {
                get { return _symbol; }
            }
        }

        // Det skulle även funka att inte ha interface, utan jobba med Investor istället

        interface IInvestor
        {
            void Update(Stock stock);
        }

        class IBM : Stock
        {
            // IBM-klassen blir väldigt enkel, den använder mest sin basklass
            public IBM(string symbol, double price)
              : base(symbol, price)
            {
            }
        }

        class Investor : IInvestor
        {
            private string _name;

            public Investor(string name)
            {
                this._name = name;
            }

            public void Update(Stock stock)
            {
                // Nu vet vi att något hänt med en av våra aktier!
                Console.WriteLine($"Notified {_name} of {stock.Symbol}'s change to {stock.Price}");
            }

        }
    }
}