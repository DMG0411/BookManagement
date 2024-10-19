using Application.DTOs;
using MediatR;

namespace Application.Use_Cases.Commands
{
    public class UpdateBookCommand : IRequest
    {
        public BookDto Book { get; set; }

        public UpdateBookCommand(BookDto book)
        {
            Book = book;
        }
    }
}
