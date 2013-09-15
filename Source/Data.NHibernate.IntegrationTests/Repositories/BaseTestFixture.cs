namespace Data.NHibernate.IntegrationTests.Repositories
{
    using System;
    using System.Transactions;

    using NHibernate.Repositories;

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
            Session = SessionHelper.GetSession();
        }

        [TearDown]
        public void TearDownTransactions()
        {

            var session = SessionHelper.GetSession();

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
            var session = SessionHelper.GetSession();
            session.Flush();
            session.Clear();
        }
    }
}