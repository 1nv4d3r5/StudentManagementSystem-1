﻿namespace Data.NHibernate.Config
{
    using System;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using Domain;

    using global::NHibernate;

    public class NHibernateSessionConfiguration
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    InitializeSessionFactory();
                }

                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void InitializeSessionFactory()
        {
            Action<MsSqlConnectionStringBuilder> connectionStringExpression =
                c => c.Database("SMS").Server(".").TrustedConnection();
            sessionFactory =
                Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionStringExpression).ShowSql())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Student>())
                        .BuildSessionFactory();
        }
    }
}