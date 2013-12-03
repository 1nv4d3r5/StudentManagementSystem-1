using System.Collections.Generic;

using Services.Models;

namespace Services.Contracts
{
    public interface IDepartmentService
    {
        List<DepartmentViewModel> GetAll();
    }
}