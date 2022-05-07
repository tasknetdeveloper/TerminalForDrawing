using Model;
using System.Windows.Controls;
namespace TerminalTest
{
    internal interface IOutput
    {
        OutputType OutputType { get; set; }
        Result Run(OutputType type, Canvas cnv);
    }
}
