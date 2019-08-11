using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyStore.Domain.Entities;

namespace MyStore.Data.Repositories
{
    public interface ICategoryRepository
    {
        List<Categories> GetAllCategories();

        List<Categories> GetAllCategories(string name);

        Categories GetCategoryById(int id);

        Categories Update(Categories categoryToUpdate);

        Categories AddCategory(Categories addedCategory);

        bool IsUniqueCategory(string name);
    }

    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<Categories> GetAllCategories()
        {
            return _storeContext.Categories.ToList();
        }

        public List<Categories> GetAllCategories(string name)
        {
            return _storeContext.Categories
                .Where(x => x.Categoryname == name)
                .ToList();
        }

        public Categories GetCategoryById(int id)
        {
            return _storeContext.Categories.Find(id);
        }

        public Categories Update(Categories categoryToUpdate)
        {
            var updatedEntity = _storeContext.Categories.Update(categoryToUpdate);

            _storeContext.SaveChanges();

            return updatedEntity.Entity;
        }

        public Categories AddCategory(Categories addedCategory)
        {
            var createdEntity = _storeContext.Categories.Add(addedCategory);

            _storeContext.SaveChanges();

            return createdEntity.Entity;
        }

        public bool IsUniqueCategory(string name)
        {
            if (_storeContext.Categories.Count(x => x.Categoryname == name) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
