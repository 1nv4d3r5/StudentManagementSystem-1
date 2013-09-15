namespace Data.NHibernate.Repositories
{
    using Config;

    using global::NHibernate;

    public class SessionHelper
    {
        private static ISessionFactory sessionFactory;

        private static ISession session;

        private static ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory ?? (sessionFactory = NHibernateSessionConfiguration.InitializeSessionFactory());
            }
        }

        public static ISession GetSession()
        {
            if (session == null || !session.IsOpen)
            {
                session = SessionFactory.OpenSession();
                session.BeginTransaction();
            }

            return session;
        }
    }
}