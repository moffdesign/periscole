using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<Error>? Errors { get; set; }
        public int? StatusCode { get; set; }

        public static Result<T> Ok(T data, int? statusCode = 200)
        {
            return new Result<T>
            {
                Success = true,
                Data = data,
                StatusCode = statusCode
            };
        }

        public static Result<T> Fail(string errorCode, string errorMessage, int? statusCode = 400)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new List<Error> { new Error { Code = errorCode, Message = errorMessage } },
                StatusCode = statusCode
            };
        }

        public static Result<T> Fail(List<Error> errors, int? statusCode = 400)
        {
            return new Result<T>
            {
                Success = false,
                Errors = errors,
                StatusCode = statusCode
            };
        }
    }

    public class Error
    {
        public string Code { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }

}
