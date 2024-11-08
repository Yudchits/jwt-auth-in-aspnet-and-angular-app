namespace Marketplace.DataAccess.Common.Helpers
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        private Result(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public static Result<T> Ok(T data)
        {
            return new Result<T>(true, data, null);
        }

        public static Result<T> Fail(string message)
        {
            return new Result<T>(false, default, message);
        }
    }
}