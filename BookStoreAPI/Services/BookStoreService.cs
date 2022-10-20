using BookStoreAPI.DataAccess;
using BookStoreAPI.Exceptions;
using BookStoreAPI.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAPI.Services
{
    public class BookStoreService : IBookStoreService
    {
        private readonly BookStoreContext _bookStore;

        public BookStoreService(BookStoreContext bookStore)
        {
            _bookStore = bookStore;
        }

        public async Task<List<Book>> GetAll()
        {
            var records = await _bookStore.Books.ToListAsync();
            return records;
        }

        public async Task<Book> GetById(int bookId)
        {
            var record = await _bookStore.Books.Where(x => x.Id == bookId).FirstOrDefaultAsync();
            return record;
        }

        public async Task<int> AddBook(Book books)
        {
            books.Id = 0;
            if (books.Title == null || books.Title == "")
                return -1;
            _bookStore.Books.Add(books);
            await _bookStore.SaveChangesAsync();
            return 0;
        }

        public int UpdateBook(int bookId,Book books)
        {
            books.Id = bookId;
            var book = _bookStore.Books.Where(x => x.Id == bookId).FirstOrDefault();
            if(book == null)
                return -1;
            _bookStore.Update(books);
           
            _bookStore.SaveChanges();
            return 0;
        }

        public int DeleteBook(int bookId)
        {
            var book = _bookStore.Books.Where(x => x.Id == bookId).FirstOrDefault();
            if(book!= null) {
                _bookStore.Remove(book);
                _bookStore.SaveChanges();
                return 1;
            }
            
            return 0;
            
        }
    }
}
