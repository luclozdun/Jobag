using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jobag.src.Resume.Domain.Result;
using Jobag.src.Shared.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Jobag.src.Resume.Application.Internal.Queries.PostulantQueries.PostulantInformation
{
    public class PostulantInformationQuery : IQuery<PostulantResult>
    {
        public int Id { get; set; }

        public PostulantInformationQuery(int id)
        {
            Id = id;
        }
    }
}