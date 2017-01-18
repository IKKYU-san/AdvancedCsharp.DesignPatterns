// Kolla först på introvideon
// Bilden "ObserverExpectedOutput.png" visar vilket resultat som förväntas av uppgiften
// Använd "Observer-pattern" för att lösa uppgiften

namespace AdvancedCsharp.DesignPatterns.Observer
{
    
    using System;
    using System.Collections.Generic;

    public class ObserverAssignement
    {
        // Ändra inget i följande Run-metoden

        public void Run()
        {
            var website = new Website("My website");

            var page1 = new Page("Page1");
            var page2 = new Page("Page2");

            var dialog1 = new Dialog("Dialog1");
            var dialog2 = new Dialog("Dialog2");
            var dialog3 = new Dialog("Dialog3");
            var dialog4 = new Dialog("Dialog4");
            var dialog5 = new Dialog("Dialog5");
            var dialog6 = new Dialog("Dialog6");
            var dialog7 = new Dialog("Dialog7");

            page1.Dialogs = new List<Dialog>
            {
                dialog1,
                dialog2,
                dialog3,
                dialog4
            };

            page2.Dialogs = new List<Dialog>
            {
                dialog5,
                dialog6,
                dialog7
            };

            website.Pages = new List<Page>
            {
                page1,
                page2
            };

            website.Color = ConsoleColor.Blue;  // Nu ska automatiskt alla sidor och dialoger bli blå
            page2.Color = ConsoleColor.Red;     // Nu ska automatiskt page2 och alla dialoger under page2 bli röda
            dialog1.Color = ConsoleColor.Green; // Detta ska sätta  dialog1's färg till grön
            dialog3.Color = ConsoleColor.Green; // Detta ska sätta  dialog3's färg till grön
            dialog7.Color = ConsoleColor.Green; // Detta ska sätta  dialog7's färg till grön

            Gui.SetupConsoleWindow();
            Gui.DrawPagesWithDialogs(website);

        }

        // Denna klass behöver utökas/modifieras
        class Gui
        {
            static public void DrawPagesWithDialogs(Website website)
            {
                // Rita ut GUI't utifrån "website"
            }

            static public void SetupConsoleWindow()
            {
                //Console.WindowWidth = 34;
                //Console.WindowHeight = 58;
            }

        }

        // Denna klass behöver utökas/modifieras
        class Website 
        {
            public string Name { get; }

            public Website(string name)
            {
                Name = name;
            }

            public ConsoleColor Color{ get; set; }
            public List<Page> Pages { get; set; }
        }

        // Denna klass behöver utökas/modifieras
        class Page 
        {
            public string Name { get; }

            public Page(string name)
            {
                Name = name;
            }

            public ConsoleColor Color { get; set; }
            public List<Dialog> Dialogs { get; set; }


        }

        // Denna klass behöver utökas/modifieras
        class Dialog 
        {
            public string Name { get; }

            public Dialog(string name)
            {
                Name = name;
            }

            public ConsoleColor Color { get; set; }

        }
        
    }
}