using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    internal class Program
    {
        abstract class Page
        {
            public abstract void Print();
        }

        class SkillsPage : Page
        {
            public SkillsPage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("Skills Page");
            }
        }
        class EducationalPage : Page
        {
            public EducationalPage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("EducationalPage");
            }
        }

        class ExperiencePage : Page
        {
            public ExperiencePage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("ExperiencePage");
            }
        }
        class IntroductionPage : Page
        {
            public IntroductionPage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("IntroductionPage");
            }
        }
        class ResultsPage : Page
        {
            public ResultsPage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("ResultsPage");
            }
        }

        class ConclusionPage : Page
        {
            public ConclusionPage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("ConclusionPage");
            }
        }

        class SummaryPage : Page
        {
            public SummaryPage()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("SummaryPage");
            }
        }

        class Bibliograpy : Page
        {
            public Bibliograpy()
            {
                Print();
            }
            public override void Print()
            {
                Console.WriteLine("Bibliograpy");
            }
        }


        abstract class Document
        {
            private List<Page> _pages = new List<Page>();
            public Document()
            {
                this.CreatePage();
            }

            public List<Page> Pages
            {
                get { return _pages; }
            }
            public abstract void CreatePage();
        }


        class Resume : Document
        {
            public override void CreatePage()
            {
                Pages.Add(new SkillsPage());
                Pages.Add(new EducationalPage());
                //Pages.Add(new ExperiencePage());
                //Pages.Add(new ExperiencePage());
            }
        }


        class Report : Document
        {
            public override void CreatePage()
            {
                Pages.Add(new IntroductionPage());
                Pages.Add(new ResultsPage());
                Pages.Add(new ConclusionPage());
                Pages.Add(new SummaryPage());
                Pages.Add(new Bibliograpy());
            }
        }


        static void Main(string[] args)
        {
            Document[] documents = new Document[2];
            documents[0] = new Resume();
            Console.WriteLine("-----------------------");
            documents[1] = new Report();            
        }
    }
}
