using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Application.GenericResponses
{
    public class Results<T>
    {
        public bool IsSucssed { get; set; }
        public T Value { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public static Results<T> Success(T value)
        {
            return new Results<T> { IsSucssed = true, Value = value, StatusCode = 200 };
        }
        public static Results<T> Failure(string message)
        {
            return new Results<T> { IsSucssed = false, ErrorMessage = message, StatusCode = 400 };
        }
        public static Results<T> Unauthorized(string message)
        {
            return new Results<T> { IsSucssed = false, ErrorMessage = message, StatusCode = 403 };
        }
        public static Results<T> NotFound(string message)
        {
            return new Results<T> { IsSucssed = false, ErrorMessage = message, StatusCode = 404 };
        }
    }
}
