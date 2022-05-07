using Xunit;
using System.Windows.Controls;
using TerminalTest.Model;
namespace TestProject2
{
    public class UnitTest1
    {
        
        [Fact]
        public void Test1()
        {
            
        }

        [WpfFact]
        public void DrawCircle()
        {
            Circle circle = new Circle();
            
            var d = new System.Collections.Generic.Dictionary<Model.FigureParameterName, object>();
            d.Add(Model.FigureParameterName.Radius, 40);
            var result = circle.Draw(new Canvas(), d);
            
            Assert.NotNull(circle);
            Assert.NotNull(result);
        }

        [WpfFact]
        public void DrawRactangle()
        {
            var rectangle = new TerminalTest.Model.Rectangle(); 

            var d = new System.Collections.Generic.Dictionary<Model.FigureParameterName, object>();
            d.Add(Model.FigureParameterName.W, 40);
            d.Add(Model.FigureParameterName.H, 20);
            var result = rectangle.Draw(new Canvas(), d);

            Assert.NotNull(rectangle);
            Assert.NotNull(result);
        }

        [WpfFact]
        public void DrawTriangle()
        {
            var triangle = new TerminalTest.Model.Triangle();

            var d = new System.Collections.Generic.Dictionary<Model.FigureParameterName, object>();
            d.Add(Model.FigureParameterName.Points, "1,50;10,80;50,50;");
            
            var result = triangle.Draw(new Canvas(), d);

            Assert.NotNull(triangle);
            Assert.NotNull(result);
        }
        
    }
}