﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext context;

        public BookRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<Guid> AddAsync(Book book)
        {
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return book.Id;
        }

        public async Task DeleteAsync(Guid id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
           return await context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(Guid id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if(book == null)
            {
                throw new Exception("Book not found");
            }
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            context.Books.Update(book);
            await context.SaveChangesAsync();
        }
    }
}
