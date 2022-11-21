using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.Result
{
    public abstract class BaseResult<T>
    {
        public bool Success { get; set; }
        public String Message { get; set; }
        public T Resource { get; set; }

        public BaseResult(T resource)
        {
            Success = true;
            Resource = resource;
        }

        public BaseResult(string message)
        {
            Success = false;
            Message = message;
        }
    }
}