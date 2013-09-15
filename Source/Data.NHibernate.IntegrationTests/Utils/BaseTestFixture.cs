namespace Data.NHibernate.IntegrationTests.Utils
{
    using System;
    using System.Transactions;

    using NHibernate.Utils;

    using NUnit.Framework;

    using global::NHibernate;

    public class BaseTestFixture
    {
        protected ISession Session;

        protected ISessionFactory SessionFactory;

        private TransactionScope transactionScope;

        [SetUp]
        public void SetUpTransactions()
        {
            this.transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, new TimeSpan(0, 0, 1, 0));
            this.Session = SessionProvider.GetSession();
        }

        [TearDown]
        public void TearDownTransactions()
        {

            var session = SessionProvider.GetSession();

            if (session.Transaction.IsActive)
            {
                session.Transaction.Rollback();
            }
            if (session.IsOpen)
            {
                session.Clear();
                session.Close();
            }

            this.transactionScope.Dispose();
        }

        protected void FlushAndClearSession()
        {
            var session = SessionProvider.GetSession();
            session.Flush();
            session.Clear();
        }
    }
}