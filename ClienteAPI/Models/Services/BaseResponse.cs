using System;

namespace ClienteAPI.Models.Services
{
    public abstract class BaseResponse<T>
    {
        public T Resource { get; }

        public bool Success { get; }

        public string[] Message { get; }

        public BaseResponse(T resource)
        {
            Resource = resource;
            Success = true;
            Message = Array.Empty<string>();
        }

        public BaseResponse(string[] message)
        {
            Resource = default;
            Success = false;
            Message = message;
        }
    }
}