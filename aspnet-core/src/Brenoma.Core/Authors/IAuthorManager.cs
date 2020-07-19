using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Authors
{
    public interface IAuthorManager : IDomainService
    {
        Task CreateAsync(Author author);
        Task<Author> GetAsync(Guid id);
    }
}
