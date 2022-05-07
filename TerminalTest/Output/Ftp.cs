using System.Windows.Controls;
using Model;
namespace TerminalTest
{
    internal class Ftp : OutputBase, IOutput
    {
        internal Ftp()
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
