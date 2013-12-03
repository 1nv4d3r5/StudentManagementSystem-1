using System.Collections.Generic;

using Services.Models;

namespace Services.Contracts
{
    public interface IStudentService
    {
        List<StudentViewModel> GetAll();
    }
}