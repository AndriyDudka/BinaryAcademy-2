using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProject
{
    

    public class ConsoleLogger: ILogger
    {
        public void Info(string text)
        {
            Console.WriteLine(text);
        }

        public void Debug()
        {
            
        }

        public void Warning()
        {
            
        }

        public void Error()
        {
            
        }
    }

    public class FileLogger : ILogger
    {
        public void Info(string text)
        {
            
        }

        public void Debug()
        {
            
        }

        public void Warning()
        {
            
        }

        public void Error()
        {
            
        }
    }
}
