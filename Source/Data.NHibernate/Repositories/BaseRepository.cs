namespace Data.NHibernate.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using global::NHibernate;
    using global::NHibernate.Linq;

    public class BaseRepository<TDomain> where TDomain : class
    {
        public TDomain GetById(int id)
        {
            return GetSession().Get<TDomain>(id);
        }

        public List<TDomain> GetAll()
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

        private static ISession GetSession()
        {
            return SessionHelper.GetSession();
        }
    }
}