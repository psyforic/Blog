using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Posts
{
   public interface IPostManager:IDomainService
    {
        Task CreateAsync(Post post);
        Task<Post> GetAsync(Guid id);
    }
}
