using System.Collections.Generic;

using Services.Models;

namespace Services.Contracts
{
    public interface IService<TViewModel> where TViewModel : ViewModel
    {
        List<TViewModel> GetAll();
    }
}