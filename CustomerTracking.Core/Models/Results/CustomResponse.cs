﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CustomerTracking.Core.Models.Results
{
    public class CustomResponse<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }


        public static CustomResponse<T> Success(int statusCode,T data)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode };
        }

        public static CustomResponse<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponse<T> Fail(int statusCode, string errors)
        {
            return new CustomResponse<T> { StatusCode = statusCode, Errors = new List<string> { errors } };
        }
    }
}
