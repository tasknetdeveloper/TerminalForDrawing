using System.Collections.Generic;

namespace Model
{
    public class Figure
    {
        public const string MSG_success = "The figure is drawn successfully\r\n";
        public const string MSG_error = "The error of drawing the figure\r\n";
        public Dictionary<FigureParameterName, int> InputParameter { get; set; }
        public FigureType FigureType { get; set; }

       
    }
}
