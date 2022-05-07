using System.Windows;
using System.Windows.Input;

namespace TerminalTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CommandLine CommandLine=null;
        public MainWindow()
        {
            InitializeComponent();
            Ini();
            
        }

        private void Ini() {
            this.description.Text = Static.help;
            CommandLine = new();
            terminalTextBox.KeyDown += (_, e) => {
                if (e.Key == Key.Enter)
                {
                    CommandLine.CommandRun(terminalTextBox.Text, this.WorkCanvas, this.terminalTextBox, this.terminalLog);
                }
            };
            terminalTextBox.PreviewMouseDown += (_, _) => {
                terminalTextBox.Text = "";
                WorkCanvas.Focus();
            };
            terminalTextBox.LostFocus += (_, _) => {
                terminalTextBox.Text = "...";
            };
        }
    }
}
