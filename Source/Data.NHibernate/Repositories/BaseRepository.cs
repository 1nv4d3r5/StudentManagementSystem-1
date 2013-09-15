namespace Data.NHibernate.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Config;

    using global::NHibernate.Linq;

    public class BaseRepository<TDomain> where TDomain : class
    {
        public TDomain GetById(int id)
        {
            using (var session = NHibernateSessionConfiguration.OpenSession())
            {
                return session.Get<TDomain>(id);
            }
        }

        public List<TDomain> GetAll()
        {
            using (var session = NHibernateSessionConfiguration.OpenSession())
            {
                return session.Query<TDomain>().ToList();
            }
        }
    }
}