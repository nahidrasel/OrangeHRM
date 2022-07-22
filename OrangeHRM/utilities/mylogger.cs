
using System;
using System.IO;

namespace OrangeHRM.utilities
{
    namespace mylogger
    {
        public abstract class LogBase
        {
            public abstract void Log(string Messsage);
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

            public Logger()
            {
                this.CurrentDirectory = Environment.CurrentDirectory;
                String projectDirectory = Directory.GetParent(this.CurrentDirectory).Parent.Parent.FullName;
                this.FileName = "MyLog.txt";
                this.FilePath = projectDirectory + "/" + this.FileName;

            }

            public override void Log(string Messsage)
            {
                System.Console.WriteLine("INF : {0}", Messsage);

                using System.IO.StreamWriter sw = System.IO.File.AppendText(this.FilePath);
                sw.Write("\r\nINF : ");
                sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                sw.WriteLine("  :{0}", Messsage);
                sw.WriteLine("-----------------------------------------------");
            }
        }
    }
}
