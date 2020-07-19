using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Brenoma.Categories.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Categories
{
    public class CategoryAppService : BrenomaAppServiceBase, ICategoryAppService
    {
        private readonly ICategoryManager _categoryManager;
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryAppService(ICategoryManager categoryManager, IRepository<Category, Guid> categoryRepository)
        {
            _categoryManager = categoryManager;
            _categoryRepository = categoryRepository;
        }
        public async Task CreateAsync(CategoryCreateInput input)
        {
            var category = ObjectMapper.Map<Category>(input);
            await _categoryManager.CreateAsync(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await _categoryManager.GetAsync(id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<ListResultDto<CategoryListDto>> GetAll()
        {
            var categories = await _categoryRepository
                .GetAll()
                .ToListAsync();
            if (categories != null)
            {
                return new ListResultDto<CategoryListDto>(ObjectMapper.Map<List<CategoryListDto>>(categories));
            }
            return null;
        }

        public async Task<CategoryListDto> GetById(Guid id)
        {
            var category = await _categoryManager.GetAsync(id);
            return ObjectMapper.Map<CategoryListDto>(category);
        }

        public async Task UpdateCategory(CategoryDto input)
        {
            var category = await _categoryManager.GetAsync(input.Id);
            var id = input.Id;
            ObjectMapper.Map(input, category);
            category.Id = id;
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
