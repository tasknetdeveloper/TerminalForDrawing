using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Model;
namespace TerminalTest
{
    internal class Printer : OutputBase, IOutput
    {
        internal Printer()
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
