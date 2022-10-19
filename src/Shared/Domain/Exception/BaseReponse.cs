using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Shared.Domain.Exception
{
    public abstract class BaseReponse<T>
    {
        public bool Success { get; set; }
        public String Message { get; set; }
        public T Resource { get; set; }

        public BaseReponse(T resource)
        {
            Success = true;
            Resource = resource;
        }

        public BaseReponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}