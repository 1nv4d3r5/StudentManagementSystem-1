namespace Data.NHibernate.Maps
{
    using Domain;

    using FluentNHibernate.Mapping;

    public class DepartmentMap : ClassMap<Department>
    {
        public DepartmentMap()
        {
            this.Schema("Core");
            this.Table("Department");
            this.Id(department => department.Id);
            this.Map(department => department.Code);
            this.Map(department => department.Name);
        }
    }
}