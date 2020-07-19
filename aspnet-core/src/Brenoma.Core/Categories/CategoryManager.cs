using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Categories
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryManager(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(Category category)
        {
            await _categoryRepository.InsertAsync(category);
        }

        public async Task<Category> GetAsync(Guid id)
        {
            var category = await _categoryRepository.FirstOrDefaultAsync(id);
            if(category != null)
            {
                return category;
            }
            else
            {
                throw new UserFriendlyException("Category Not Found Maybe It's Deleted");
            }
        }
    }
}
