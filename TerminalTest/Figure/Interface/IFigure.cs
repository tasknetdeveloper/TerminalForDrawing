using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Model;
namespace TerminalTest.Model
{
    public interface IFigure
    {
        FigureType FigureType { get; set; }
        Canvas cnv { get; set; }
        Result OutputTo(Func<OutputType, Canvas, Result> action, OutputType type);
        Result Draw(Canvas cnv, Dictionary<FigureParameterName, object> parameters);
    }
}
