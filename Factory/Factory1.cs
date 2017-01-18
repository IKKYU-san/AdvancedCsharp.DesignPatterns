// http://www.dofactory.com/net/factory-method-design-pattern

namespace AdvancedCsharp.DesignPatterns.Factory
{
    using System;
    using System.Collections.Generic;

    public class Factory1
    {
        public void Run()
        {
            // En array av två (abstraka) dokument

            Document[] documents = new Document[3];

            // Här sätts dokumenten till konkreta objekt

            documents[0] = new Resume();
            documents[1] = new Report();
            documents[2] = new ReflectionsOnMyEducation();

            // Nu har Resume och Report automatiskt fått Page's
            // Resume och Report har själva bestämt vilka Page's som de skapat (de har skapat olika sidor)

            // Här skriver vi bara ut de två dokumenten och vilka sidor de består av 

            foreach (Document document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (Page page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }

            Console.WriteLine();
        }
    }

    // Här följer några enkla klasser som är av typen Page

    abstract class Page
    {
    }

    class SkillsPage : Page
    {
    }

    class EducationPage : Page
    {
    }

    class ExperiencePage : Page
    {
    }

    class IntroductionPage : Page
    {
    }

    class ResultsPage : Page
    {
    }

    class ConclusionPage : Page
    {
    }

    class SummaryPage : Page
    {
    }

    class BibliographyPage : Page
    {
    }

    // Detta är den abstrakta klassen som ansvarar för att skapa objekt

    abstract class Document
    {
        private List<Page> _pages = new List<Page>();

        // "Document" förväntar sig att barnet har implementerat CreatePages och gör direkt ett anrop (i konstruktorn)
        // Låter underklasserna bestämma vilken klass som ska skapas

        public Document()
        {
            this.CreatePages();
        }

        public List<Page> Pages
        {
            get { return _pages; }
        }

        // Factory Method
        public abstract void CreatePages();
    }

    // Resume är ett typ av dokument

    class Resume : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            // Skulle kunna ha detta i konstruktorn. Men det blir tydligare här att vi föräntas implementera CreatePages

            Pages.Add(new SkillsPage());
            Pages.Add(new EducationPage());
            Pages.Add(new ExperiencePage());
        }
    }

    // Report är ett typ av dokument

    class Report : Document
    {
        // Factory Method implementation
        public override void CreatePages()
        {
            Pages.Add(new IntroductionPage());
            Pages.Add(new ResultsPage());
            Pages.Add(new ConclusionPage());
            Pages.Add(new SummaryPage());
            Pages.Add(new BibliographyPage());
        }
    }


    class ReflectionsOnMyEducation : Document
    {
        public override void CreatePages()
        {
            Pages.Add(new EducationPage());
            Pages.Add(new SummaryPage());
        }
    }

}
