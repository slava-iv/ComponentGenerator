using System.IO;

namespace AngularComponent
{
    public class Template
    {
        public string FilePrefix { get; set; }

        public string TempalteFile { get; set; }

        public string GetTemplate()
        {
            return File.ReadAllText(TempalteFile);
        }
    }
}
