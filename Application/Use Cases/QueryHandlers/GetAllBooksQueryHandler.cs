using Application.DTOs;
using Application.Use_Cases.Queries;
using AutoMapper;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.QueryHandlers
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery,IEnumerable<BookDto>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllBooksQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }
    }
}
