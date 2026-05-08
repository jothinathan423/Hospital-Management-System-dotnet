using System.Net;

namespace HMS.Entity.Models.ResponseModels
{
    public class GenericApiResponse<T>
    {
        private const string SuccessStatus = "Success";
        private const string FailureStatus = "Failure";

        public int StatusCode { get; set; }

        public string StatusMsg { get; set; } = string.Empty;

        public ICollection<string> ErrorMsg { get; set; } = new List<string>();

        public T? Response { get; set; }

        public GenericApiResponse<T> SuccessResponse(T response)
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.OK,
                StatusMsg = SuccessStatus,
                Response = response
            };
        }

        public GenericApiResponse<T> SuccessResponseForPost(T response)
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.Created,
                StatusMsg = SuccessStatus,
                Response = response
            };
        }

        public GenericApiResponse<T> ErrorResponse(string message)
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.BadRequest,
                StatusMsg = FailureStatus,
                ErrorMsg = new List<string> { message }
            };
        }

        public GenericApiResponse<T> InternalErrorResponse(string message)
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                StatusMsg = FailureStatus,
                ErrorMsg = new List<string> { message }
            };
        }

        public GenericApiResponse<T> InternalErrorResponse(Exception exception)
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                StatusMsg = FailureStatus,
                ErrorMsg = new List<string>
                {
                    $"{exception.Message} InnerException: {exception.InnerException}"
                }
            };
        }

        public GenericApiResponse<T> Unauthorized()
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.Unauthorized,
                StatusMsg = FailureStatus,
                ErrorMsg = new List<string> { "Unauthorized" }
            };
        }

        public GenericApiResponse<T> Forbidden()
        {
            return new GenericApiResponse<T>
            {
                StatusCode = (int)HttpStatusCode.Forbidden,
                StatusMsg = FailureStatus,
                ErrorMsg = new List<string> { "Forbidden" }
            };
        }

        public GenericApiResponse<T> BuildResponse(
            int statusCode,
            string statusMsg,
            List<string>? errorMessages = default,
            T? response = default)
        {
            var apiResponse = new GenericApiResponse<T>
            {
                StatusCode = statusCode,
                StatusMsg = statusMsg
            };

            if (errorMessages?.Count > 0)
            {
                apiResponse.ErrorMsg = errorMessages;
            }

            if (response is not null)
            {
                apiResponse.Response = response;
            }

            return apiResponse;
        }
    }
}
