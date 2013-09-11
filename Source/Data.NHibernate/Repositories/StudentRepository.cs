namespace Data.NHibernate.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using Config;

    using Domain;

    using global::NHibernate.Linq;

    public class StudentRepository
    {
        public Student GetById(int id)
        {
            using (var session = NHibernateSessionConfiguration.OpenSession())
            {
                return session.Get<Student>(id);
            }
        }

        public List<Student> GetAll()
        {
            using (var session = NHibernateSessionConfiguration.OpenSession())
            {
                return session.Query<Student>().ToList();
            }
        }
    }
}