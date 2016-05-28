using System;

namespace LoggerProject
{ 
    public class ConsoleLogger: ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine("Info. " + message);
        }

        public void Debug(string log)
        {
            Console.WriteLine("Debug. " + log);
        }

        public void Warning(string log)
        {
            Console.WriteLine("Warning. " + log);
        }

        public void Error(string log)
        {
            Console.WriteLine("Error. " + log);
        }

        public void Dispose() { }
    }
}
