using Model;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Collections.Generic;
using System;

namespace TerminalTest.Model
{
    /// <summary>
    /// класс фигуры "круг"
    /// </summary>
    public class Circle:Figure, IFigure
    {
        private CommonBase CommonBase = new();
        public Canvas cnv  { get; set; }

        public Circle()
        {
            FigureType = FigureType.Circle;
        }

        public Result OutputTo(Func<OutputType, Canvas, Result> action, OutputType type)
        {
            return action(type, cnv);
        }

        public Result Draw(Canvas cnv, Dictionary<FigureParameterName, object> parameters)
        {
            Result result = new();
            result.Message = MSG_error;
            if (cnv != null)
            {
                cnv.Children.Clear();
                var el = new Ellipse();
                var mySolidColorBrush = new SolidColorBrush();
                mySolidColorBrush.Color = Static.backgroundColor;
                el.Fill = mySolidColorBrush;
                el.StrokeThickness = 1;
                el.Stroke = Static.strokeColor;

                try
                {
                    el.Width = int.Parse(CommonBase.GetNormalizeEnumStr(parameters[FigureParameterName.Radius].ToString())) * 2;
                    el.Height = int.Parse(CommonBase.GetNormalizeEnumStr(parameters[FigureParameterName.Radius].ToString())) * 2;
                    
                    double left = (cnv.ActualWidth - el.Width) / 2;
                    double top = (cnv.ActualHeight - el.Height) / 2;
                    el.Margin = new System.Windows.Thickness(left, top, 0, 0);

                    cnv.Children.Add(el);
                    cnv.UpdateLayout();
                    this.cnv = cnv;
                    result.ResultType = ResultType.Success;
                    result.Message = MSG_success;
                }
                catch (Exception exp)
                {
                    result.ResultType = ResultType.Error;
                    result.Message = MSG_error + " " + exp.Message;
                }
            }
            return result;
        }
        
    }
}
