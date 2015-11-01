using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using RazorEngine;

namespace AngularComponent
{
    public class Generator
    {
        public void Generate(Template[] templates, string name, string outputPath)
        {
            var camelName = CamelCase(name);

            var outputFolder = outputPath + "\\" + name;
            var context = new Context { Name = name.ToLower(), CamelName = camelName };

            CreateFolder(outputFolder);

            foreach (var template in templates)
            {
                var file = GenerateFile(template.GetTemplate(), context);
                File.WriteAllText(outputFolder + "\\" + name + template.FilePrefix, file);
            }
        }

        protected string GenerateFile(string template, Context context)
        {
            return Razor.Parse(template, context);
        }

        private void CreateFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public static string CamelCase(string name)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            var parts = name.Split(new[] {'_', '-'}, StringSplitOptions.RemoveEmptyEntries);

            parts[0] = parts[0].ToLower();

            for (int i = 1; i < parts.Length; i++)
            {
                parts[i] = textInfo.ToTitleCase(parts[i]);
            }

            return parts.Aggregate(string.Concat);
        }
    }
}
