using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using Model;

namespace TerminalTest.Model
{
    public class Square : Figure, IFigure
    {
        private CommonBase CommonBase = new();
        public Canvas cnv { get; set; }

        public Square()
        {
            FigureType = FigureType.Square;
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

                System.Windows.Shapes.Rectangle rect;
                rect = new System.Windows.Shapes.Rectangle();
                rect.Stroke = Static.strokeColor;
                rect.Fill = new SolidColorBrush(Static.backgroundColor);
                try
                {
                    rect.Width = int.Parse(CommonBase.GetNormalizeEnumStr(parameters[FigureParameterName.Sidesize].ToString()));
                    rect.Height = rect.Width;

                    double left = (cnv.ActualWidth - rect.Width) / 2;
                    double top = (cnv.ActualHeight - rect.Height) / 2;
                    rect.Margin = new System.Windows.Thickness(left, top, 0, 0);

                    cnv.Children.Add(rect);
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

