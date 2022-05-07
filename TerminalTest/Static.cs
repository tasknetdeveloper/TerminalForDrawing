using System.Windows.Media;

namespace TerminalTest
{
    internal static class Static
    {        
        internal static int dpi = 90;
        internal static string filename = @"d:\tmp\testscreen.png";
        internal static Color backgroundColor = Colors.GreenYellow;
        internal static Brush strokeColor = Brushes.White;
        internal const string msgBadCommand = " is a bad command";
        internal const string help = "" +
            "Strict mask: Command Figure Parameters \r\n" +
            "Command: File - Preservation of the figure to the disk; Screen - Figure output only on the screen \r\n" +
            "Figure: circle (paramater: radius); rectangle (parameters: W,H);Triangle (parameters: Points=X,Y;X,Y;X,Y;)\r\n" +
            "Examples of the command line:\r\n" +
                "Screen circle radius=50\r\n" +
                "Screen rectangle w=50 h=170\r\n" +
                "File Rectangle W=50 H=170\r\n" +
                "File circle radius=50\r\n" +
                "File Triangle Points=1,50;10,80;50,50;\r\n";
    }
}
