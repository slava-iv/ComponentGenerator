using System;
using System.IO;
using System.Linq;

namespace AngularComponent
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory(); 
            var generator = new Generator();

            string name = null;

            if (args != null && args.Any())
            {
                name = args[0];
            }

            if (!string.IsNullOrEmpty(name))
            {
                try
                {
                    var templateFiles = GetTemplates();

                    if (templateFiles.Any())
                    {
                        var templates = GetTemplates();
                        generator.Generate(templates, name, currentDirectory);
                    }

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Success generated.");
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            else
            {
                ShowErrorMessage("Error: Name is required.");
            }
        }

        static Template[] GetTemplates()
        {
            //This is temporary stub.
            return new []
            {
                new Template() { FilePrefix = ".controller.js", TempalteFile = "Templates/controller.cshtml" },
                new Template() { FilePrefix = ".directive.js", TempalteFile = "Templates/directive.cshtml" },
                new Template() { FilePrefix = ".service.js", TempalteFile = "Templates/service.cshtml" },
                new Template() { FilePrefix = ".template.html", TempalteFile = "Templates/template.cshtml" }
            };
        }

        static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
        }

        static void ShowError(Exception error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error.Message);
            Console.WriteLine(error.StackTrace);
        }
    }
}
