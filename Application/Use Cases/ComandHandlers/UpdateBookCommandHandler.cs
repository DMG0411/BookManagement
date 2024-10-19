using Application.DTOs;
using Application.Use_Cases.Commands;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _repository;

        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(_mapper.Map<Book>(request.Book));
        }
    }
}
