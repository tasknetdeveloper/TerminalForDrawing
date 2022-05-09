using System.Collections.Generic;
using System.Linq;
using Model;
using System.Windows.Controls;
using TerminalTest.Model;

namespace TerminalTest
{
    /// <summary>
    /// класс командной строки
    /// </summary>
    internal class CommandLine: CommonBase
    {
        private const char CmdLine_SEPARATOR = ' ';
        private List<IFigure> listIFigure= new ();
        private List<IOutput> listIOutput = new();
        internal CommandLine() {
            listIFigure.Add(new Circle());
            listIFigure.Add(new Rectangle());
            listIFigure.Add(new Triangle());
            listIFigure.Add(new Square());

            listIOutput.Add(new Email());
            listIOutput.Add(new File());
            listIOutput.Add(new Ftp());
            listIOutput.Add(new Printer());
        }

        internal void CommandRun(string command, Canvas cnv, TextBox txtBox, TextBlock terminalLog)
        {
            var arr = command.Split(CmdLine_SEPARATOR);
            var ft = FigureType.Empty;
            var ot = OutputType.Empty;
            if (arr != null && arr.Length > 2)
            {
                ot = GetOutputType(arr[0].Trim());
                ft = GetFigureType(arr[1].Trim());

                //остальные параметры командной строки (пример: w=100 h=50 radius=100)
                var p = new Dictionary<FigureParameterName, object>();
                var i = 2;

                while (i < arr.Length)
                {
                    if (!string.IsNullOrEmpty(arr[i]))
                    {
                        var gp = GetPair(arr[i]);
                        if (!p.ContainsKey(gp.fgName))
                            p.Add(gp.fgName, gp.val);
                    }
                    i++;
                }

                var txt = "";
                Result resOutput = null;
                var r = listIFigure.Where(x => x.FigureType == ft).FirstOrDefault();
                if (r != null && p != null && cnv != null)
                {
                    var drawRes = r.Draw(cnv, p);

                    if (ot != OutputType.Empty && drawRes.ResultType == ResultType.Success)
                    {
                        var r2 = listIOutput.Where(x => x.OutputType == ot).FirstOrDefault();
                        if (r2 != null)
                        {
                            resOutput = r.OutputTo(r2.Run, ot);
                        }
                    }
                    txt = drawRes.Message + "" + ((resOutput!=null)? resOutput.Message:"");
                }
                terminalLog.Text = "\r\n" + command + "\r\n" + txt + "\r\n" + terminalLog.Text;
            }
            else
            {
                terminalLog.Text = command + Static.msgBadCommand + "\r\n" + terminalLog.Text;
                txtBox.Text = "";
            }
        }
    }
}
