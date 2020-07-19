using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Brenoma.Categories.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Categories
{
    public interface ICategoryAppService : IApplicationService
    {
        Task CreateAsync(CategoryCreateInput input);
        Task DeleteAsync(Guid id);
        Task UpdateCategory(CategoryDto input);
        Task<CategoryListDto> GetById(Guid id);
        Task<ListResultDto<CategoryListDto>> GetAll();
    }
}
