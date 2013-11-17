namespace Domain
{
    public interface IDepartmentRepository :IBaseRepository<Department>
    {
        Department GetByCode(string departmentCode);
    }
}