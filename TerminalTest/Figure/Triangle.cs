using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using Model;
using System.Windows;

namespace TerminalTest.Model
{
    /// <summary>
    /// класс фигуры "треугольник"
    /// </summary>
    public class Triangle : Figure, IFigure
    {
        private CommonBase CommonBase = new();
        public Canvas cnv { get; set; }
        public Triangle() {
            FigureType  = FigureType.Triangle;
        }
        public Result OutputTo(Func<OutputType, Canvas, Result> action, OutputType type)
        {
            return action(type, cnv);
        }

        //points=1,1;20,20;10,10;
        public Result Draw(Canvas cnv, Dictionary<FigureParameterName, object> parameters)
        {
            Result result = new ();
            System.Windows.Point[] points =CommonBase.GetPoints(parameters[FigureParameterName.Points].ToString(), ';',',');

            result.Message = MSG_error;
            if (cnv == null || points==null || points.Length>3) return result;
            
            cnv.Children.Clear();

            Polygon p = new();
            p.Stroke = Static.strokeColor;
            p.Fill = new SolidColorBrush(Static.backgroundColor);
            p.StrokeThickness = 1;
            p.HorizontalAlignment = HorizontalAlignment.Left;
            p.VerticalAlignment = VerticalAlignment.Center;
            
            p.Points = new();
            if (points != null)
            {
                foreach (var item in points)
                {
                    p.Points.Add(new System.Windows.Point(item.X, item.Y));
                }
            }

            cnv.Children.Add(p);
            cnv.UpdateLayout();
            this.cnv = cnv;

            result.ResultType = ResultType.Success;
            result.Message = MSG_success;            
            
            return result;
        }

    }
}
