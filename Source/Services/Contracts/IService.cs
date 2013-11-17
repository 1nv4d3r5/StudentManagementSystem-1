using System.Collections.Generic;

using Services.Models;

namespace Services.Contracts
{
    public interface IService<T> where T: ViewModel
    {
        List<T> GetAll();
    }
}