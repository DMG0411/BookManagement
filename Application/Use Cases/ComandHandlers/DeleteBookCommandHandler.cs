using Application.Use_Cases.Commands;
using Domain.Repositories;
using MediatR;

namespace Application.Use_Cases.ComandHandlers
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _repository;

        public DeleteBookCommandHandler(IBookRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
