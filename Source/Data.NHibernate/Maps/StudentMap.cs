namespace Data.NHibernate.Maps
{
    using Domain;

    using FluentNHibernate.Mapping;

    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            this.Schema("Core");
            this.Table("Student");
            this.Id(student => student.Id);
            this.Map(student => student.RollNumber);
            this.Map(student => student.FirstName);
            this.Map(student => student.MiddleName);
            this.Map(student => student.LastName);
            this.Map(student => student.JoinDate).ReadOnly();
            this.References(student => student.Department).Column("DepartmentId");
        }
    }
}