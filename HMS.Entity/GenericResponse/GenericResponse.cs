namespace HMS.Entity.GenericResponse
{
    public class GenericResponse<T>
    {
        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        public string StatusMessage { get; set; } = string.Empty;

        public T? Data { get; set; }

        public List<string> Errors { get; set; } = new();

        public static GenericResponse<T> Success(T data, string message = "Request completed successfully.", int statusCode = 200)
        {
            return new GenericResponse<T>
            {
                IsSuccess = true,
                StatusCode = statusCode,
                StatusMessage = message,
                Data = data
            };
        }

        public static GenericResponse<T> Failure(string message, int statusCode = 400, List<string>? errors = null)
        {
            return new GenericResponse<T>
            {
                IsSuccess = false,
                StatusCode = statusCode,
                StatusMessage = message,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
