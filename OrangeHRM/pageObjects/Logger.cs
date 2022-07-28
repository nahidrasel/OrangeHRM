
using System;
using System.IO;

namespace OrangeHRM.PageObjects
{
    public abstract class LogBase
    {
        public abstract void Info(string Messsage);
        public abstract void Critical(string Messsage);
    }


    public class Logger : LogBase
    {

        private string CurrentDirectory
        {
            get;
            set;
        }

        private string FileName
        {
            get;
            set;
        }

        private string FilePath
        {
            get;
            set;
        }

        public Logger(string testName)
        {
            this.CurrentDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(this.CurrentDirectory).Parent.Parent.FullName;
            var fileExternal = projectDirectory + "/External logs/";

            var DatedName = $"Execution_{DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}";

            //Directory Create
            FilePath = Path.Combine(fileExternal, DatedName);
            Directory.CreateDirectory(FilePath);

            this.FilePath = FilePath +"/" +"logs.txt";
        }

        public override void Info(string Messsage)
        {
            System.Console.WriteLine("INF : {0}", Messsage);

            using System.IO.StreamWriter sw = System.IO.File.AppendText(this.FilePath);
            sw.Write("\r\nINF : ");
            sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            sw.WriteLine("  :{0}", Messsage);
            sw.WriteLine("-----------------------------------------------");
        }

        public override void Critical(string Messsage)
        {
            System.Console.WriteLine("CRITICAL : {0}", Messsage);

            using System.IO.StreamWriter sw = System.IO.File.AppendText(this.FilePath);
            sw.Write("\r\nCritical : ");
            sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
            sw.WriteLine("  :{0}", Messsage);
            sw.WriteLine("-----------------------------------------------");
        }
    }
}
