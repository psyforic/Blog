using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Categories
{
    public interface ICategoryManager : IDomainService
    {
        Task CreateAsync(Category category);
        Task<Category> GetAsync(Guid id);
    }
}
