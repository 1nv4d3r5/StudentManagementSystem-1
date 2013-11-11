namespace Data.NHibernate.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Utils;

    using global::NHibernate;
    using global::NHibernate.Linq;

    public class BaseRepository<TDomain> where TDomain : class
    {
        public TDomain GetById(int id)
        {
            return GetSession().Get<TDomain>(id);
        }

        public virtual List<TDomain> GetAll()
        {
            return GetSession().Query<TDomain>().ToList();
        }

        public void SaveOrUpdate(TDomain domain)
        {
            GetSession().SaveOrUpdate(domain);
        }

        public void Delete(TDomain domain)
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