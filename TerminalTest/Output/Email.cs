using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Windows.Controls;
namespace TerminalTest
{
    internal class Email: OutputBase, IOutput
    {        
        internal Email()
        {
            OutputType = GetOutputType(this.GetType().Name);
        }

        public Result Run(OutputType type, Canvas cnv)
        {
            Result result = new();
            result.Message = MsgAboutFunction;
            //TODO
            return result;

        }
    }
}
