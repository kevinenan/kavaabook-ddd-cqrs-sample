using System;
using KavaaBook.Domain.Entities.PostAggregate;

namespace KavaaBook.Api.Controllers.Posts
{
    public class ReactToPostRequest
    {
        public ReactType ReactType { get; set; }
    }
}