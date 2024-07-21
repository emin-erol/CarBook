using CarBook.Application.Features.Mediator.Queries.BlogQueries;
using CarBook.Application.Features.Mediator.Results.BlogResults;
using CarBook.Application.Interfaces.BlogInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsWithAuthorsQueryHandler : IRequestHandler<GetBlogsWithAuthorsQuery, List<GetBlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRespository _repository;
        public GetBlogsWithAuthorsQueryHandler(IBlogRespository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBlogsWithAuthorsQueryResult>> Handle(GetBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetBlogsWithAuthors();
            return values.Select(x => new GetBlogsWithAuthorsQueryResult
            {
                AuthorId = x.AuthorId,
                AuthorName = x.Author.Name,
                AuthorDescription = x.Author.Description,
                AuthorImage = x.Author.ImageUrl,
                BlogId = x.BlogId,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                CoverImageUrl = x.CoverImageUrl,
                CreatedTime = x.CreatedTime,
                Title = x.Title,
                Description = x.Description
            }).ToList();
        }
    }
}
