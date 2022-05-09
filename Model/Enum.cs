
namespace Model
{
    public enum ResultType
    { 
        Error,
        Success
    }
    public enum OutputType {
        Empty = 0,
        Screen,
        File,
        Printer,
        Email,
        Ftp
        //ect.
    }

    public enum FigureType
    {
        Empty = 0,
        Circle,
        Rectangle,
        Triangle,
        Square
    }

    public enum FigureParameterName
    {
        Empty = 0,
        Radius,
        Sidesize,
        H,
        W,
        Points
    }
}
