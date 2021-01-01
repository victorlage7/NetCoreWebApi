using System.Collections.Generic;
using WebApi.Model.Base;

namespace WebApi.Repository.Interface
{
    public interface IBaseRepository<T> where T: BaseEntity
    {
        T Save(T item);

        T FindById(long id);

        List<T> FindAll();

        T Update(T item);

        void Delete(long id);

        bool Exists(long? id);
    }
}
