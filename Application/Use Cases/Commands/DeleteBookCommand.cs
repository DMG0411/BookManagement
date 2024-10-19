﻿using MediatR;

namespace Application.Use_Cases.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }

        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
    }
}
