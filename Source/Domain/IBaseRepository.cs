using System.Collections.Generic;

namespace Domain
{
    public interface IBaseRepository<T> where T : Entity
    {
        T GetById(int id);

        List<T> GetAll();

        void SaveOrUpdate(T domain);

        void Delete(T domain);

        void CommitAndCloseSession();
    }
}