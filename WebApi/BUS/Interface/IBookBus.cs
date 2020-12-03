using System.Collections.Generic;
using WebApi.Model;

namespace WebApi.BUS.Interface
{
    public interface IBookBus
    {
        Book Save(Book book);

        Book FindById(long id);

        List<Book> FindAll();

        Book Update(Book book);

        void Delete(long id);
    }
}
