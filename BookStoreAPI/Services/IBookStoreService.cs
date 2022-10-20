using BookStoreAPI.Modals;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAPI.Services
{
    public interface IBookStoreService
    {
        Task<List<Book>> GetAll();
        Task<Book> GetById(int id);
        Task<int> AddBook(Book books);
        int UpdateBook(int id, Book books);
        int DeleteBook(int bookId);
    }
}