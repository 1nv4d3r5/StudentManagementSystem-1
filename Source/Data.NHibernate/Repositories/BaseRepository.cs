namespace Data.NHibernate.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using global::NHibernate;
    using global::NHibernate.Linq;

    public class BaseRepository<TDomain> where TDomain : class
    {
        private readonly ISession session;

        public BaseRepository()
        {
            session = SessionHelper.GetSession();
        }

        public TDomain GetById(int id)
        {
            return session.Get<TDomain>(id);
        }

        public List<TDomain> GetAll()
        {
            return session.Query<TDomain>().ToList();
        }

        public void SaveOrUpdate(TDomain domain)
        {
            this.session.SaveOrUpdate(domain);
        }
    }
}