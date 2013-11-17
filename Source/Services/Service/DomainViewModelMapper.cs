using Domain;

using Omu.ValueInjecter;

using Services.Models;

namespace Services.Service
{
    public static class DomainViewModelMapper
    {
        public static T Map<T>(Entity entity) where T : ViewModel, new()
        {
            var viewModel = new T();
            viewModel.InjectFrom(entity);
            return viewModel;
        }
    }
}