using System.Collections.Generic;
using WebApi.BUS.Interface;
using WebApi.Model;
using WebApi.Repository.Interface;

namespace WebApi.BUS
{
    public class BookBus : IBookBus
    {
        private readonly IBookRepository _repository;

        public BookBus(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Save(Book book)
        {
            return _repository.Save(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public Book FindById(long id)
        {
            return _repository.FindById(id);
        }
        public List<Book> FindAll()
        {
            return _repository.FindAll();
        }

        public Book Update(Book book)
        {
            return _repository.Update(book);
        }
    }
}
