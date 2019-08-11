using System;
using System.Collections.Generic;
using System.Text;
using MyStore.Data;
using MyStore.Data.Repositories;
using MyStore.Domain.Entities;

namespace MyStore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Categories> GetAllCategories();

        Categories FindCategoryById(int id);

        Categories UpdateCategory(Categories categoryToUpdate);

        Categories AddCategory(Categories addedCategory);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Categories> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Categories FindCategoryById(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);

            if (category != null)
            {
                return category;
            }

            return null;
        }

        public Categories UpdateCategory(Categories categoryToUpdate)
        {

            return _categoryRepository.Update(categoryToUpdate);
        }

        public Categories AddCategory(Categories addedCategory)
        {
            if (IsUniqueCategory(addedCategory.Categoryname))
            {
                return _categoryRepository.AddCategory(addedCategory);
            }
            return null;
        }

        private bool IsUniqueCategory(string name)
        {
            return _categoryRepository.IsUniqueCategory(name);
        }
    }
}
