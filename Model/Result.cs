
namespace Model
{
    public class Result
    {
        public string Message { get; set; }
        public ResultType ResultType { get; set; } = ResultType.Error;
    }
}
