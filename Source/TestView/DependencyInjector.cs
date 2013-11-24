using Data.NHibernate.Repositories;

using Domain;

using Services.Contracts;
using Services.Service;

using StructureMap;

namespace TestView
{
    public static class DependencyInjector
    {
        public static void ConfigureDependencies()
        {
            ObjectFactory.Configure(action => action.For(typeof(IBaseRepository<>)).Use(typeof(BaseRepository<>)));
            ObjectFactory.Configure(action => action.For(typeof(IDepartmentRepository)).Use(typeof(DepartmentRepository)));

            ObjectFactory.Configure(action => action.For(typeof(IService<>)).Use(typeof(Service<,>)));
            ObjectFactory.Configure(action => action.For(typeof(IStudentService)).Use(typeof(StudentService)));
            ObjectFactory.Configure(action => action.For(typeof(IDepartmentService)).Use(typeof(DepartmentService)));
        }
    }
}
