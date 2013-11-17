using System.Collections.Generic;
using System.Linq;

using Domain;

using Services.Contracts;
using Services.Models;

namespace Services.Service
{
    public class Service<TEntity, TViewModel> : IService<TViewModel>
        where TViewModel : ViewModel, new() where TEntity : Entity
    {
        private readonly IBaseRepository<TEntity> repository;

        public Service(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public List<TViewModel> GetAll()
        {
            var students = repository.GetAll();
            return students.Select(DomainViewModelMapper.Map<TViewModel>).ToList();
        }
    }
}