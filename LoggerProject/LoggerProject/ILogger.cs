using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerProject
{
    public interface ILogger
    {
        void Info(string text);
        void Debug();
        void Warning();
        void Error();
    }
}
