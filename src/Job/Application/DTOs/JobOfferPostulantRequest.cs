using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobag.src.Job.Application.DTOs
{
    public class JobOfferPostulantRequest
    {
        public bool State { get; }
        public string Message { get; }
    }
}