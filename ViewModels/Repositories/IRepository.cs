using System.Collections.Generic;

namespace ViewModels.Repositories
{
    public interface IRepository<TModel, in TCreateViewModel>
    {
        public IRepository<TModel, TCreateViewModel> Create(TCreateViewModel createViewModel);
        public IRepository<TModel, TCreateViewModel> Delete(TModel model);
        public IRepository<TModel, TCreateViewModel> Delete(int id);
        public List<TModel> GetAll();
        public TModel GetById(int id);
        public TModel GetByName(string name);
    }
}