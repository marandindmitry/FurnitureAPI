namespace SharedKernel
{
    public class Result<T>
        where T : class
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string ErrorMessage { get; set; }

        public Result(bool isSuccess, T value, string errorMessage)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Ok(T value)
        {
            return new Result<T>(true, value, string.Empty);
        }

        public static Result<T> Fail(string errorMessage)
        {
            return new Result<T>(false, null!, errorMessage);
        }
    }
}