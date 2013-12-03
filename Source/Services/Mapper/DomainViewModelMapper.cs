using System.Collections.Generic;
using System.Linq;

using Domain;

using Omu.ValueInjecter;

using Services.Models;

namespace Services.Mapper
{
    public static class DomainViewModelMapper<TEntity, TViewModel>
        where TEntity : Entity, new() where TViewModel : ViewModel, new()
    {
        public static TViewModel Map(TEntity entity)
        {
            var viewModel = new TViewModel();
            viewModel.InjectFrom(entity);
            return viewModel;
        }

        public static TEntity Map(TViewModel viewModel)
        {
            var entity = new TEntity();
            entity.InjectFrom(viewModel);
            return entity;
        }

        public static List<TViewModel> Map(List<TEntity> entities)
        {
            return entities.Select(Map).ToList();
        }

        public static List<TEntity> Map(List<TViewModel> viewModels)
        {
            return viewModels.Select(Map).ToList();
        }
    }
}