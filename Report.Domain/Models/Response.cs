namespace Report.Domain.Models
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default)
        {
            return new(data, message, true);
        }

        public static Response<T> Fail<T>(string message, int errorCode, T data = default) =>
            new(data, message, true, errorCode);

        public static Response<T> Ok<T>(T data, string message)
        {
            return new(data, message, false);
        }
    }

    public class Response<T>
    {
        public Response(T data, string msg, bool error, int errorCode)
        {
            Data = data;
            Message = msg;
            Error = error;
            ErrorCode = errorCode;
        }

        public Response(T data, string msg, bool error)
        {
            Data = data;
            Message = msg;
            Error = error;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
        public int ErrorCode { get; set; }
    }
}
