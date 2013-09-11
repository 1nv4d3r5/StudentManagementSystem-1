namespace Data.NHibernate.Repositories
{
    using Config;

    using Domain;

    public class StudentRepository
    {
        public Student GetById(int id)
        {
            using (var session = NHibernateSessionConfiguration.OpenSession())
            {
                return session.Get<Student>(id);
            }
        }
    }
}