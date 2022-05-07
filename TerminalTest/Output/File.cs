using System.Windows.Controls;
using Model;
namespace TerminalTest
{
    internal class File : OutputBase, IOutput
    {
        private const string MSGFileSaved = "File saved successful ";
        internal File()
        {
            OutputType = GetOutputType(this.GetType().Name);
        }

        public Result Run(OutputType type, Canvas cnv)
        {
            Result result = new();
            result.Message = SaveCanvasToFile(cnv, Static.dpi, Static.filename);            
            result.ResultType = (!string.IsNullOrEmpty(result.Message))? ResultType.Error: ResultType.Success;
            if (result.ResultType == ResultType.Success)
                result.Message = MSGFileSaved + "\t" + Static.filename;
            return result;
        }

    }
}
