using Domain;

namespace Data.NHibernate.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Utils;

    using global::NHibernate;
    using global::NHibernate.Linq;

    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        public T GetById(int id)
        {
            return GetSession().Get<T>(id);
        }

        public virtual List<T> GetAll()
        {
            return GetSession().Query<T>().ToList();
        }

        public void SaveOrUpdate(T domain)
        {
            GetSession().SaveOrUpdate(domain);
        }

        public void Delete(T domain)
        {
            GetSession().Delete(domain);
        }

        public void CommitAndCloseSession()
        {
            var session = GetSession();
            session.Transaction.Commit();
            session.Flush();
            session.Clear();
            session.Close();
        }

        protected static ISession GetSession()
        {
            return SessionProvider.GetSession();
        }
    }
}