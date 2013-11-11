namespace Data.NHibernate.Config
{
    using System;

    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;

    using Domain;

    using Maps;

    using global::NHibernate;

    public class NHibernateSessionConfiguration
    {
        internal static ISessionFactory InitializeSessionFactory()
        {
            Action<MsSqlConnectionStringBuilder> connectionStringExpression =
                c => c.Database("SMS").Server(".").TrustedConnection();
            return
                Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionStringExpression).ShowSql())
                        .Mappings(m => m.HbmMappings.AddFromAssemblyOf<Student>())
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                        .BuildSessionFactory();
        }
    }
}