using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Posts
{
    public class PostManager : IPostManager
    {
        private readonly IRepository<Post, Guid> _postRepository;

        public PostManager(IRepository<Post,Guid> postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task CreateAsync(Post post)
        {
            await _postRepository.InsertAsync(post);
        }

        public async Task<Post> GetAsync(Guid id)
        {
            var post = await _postRepository.FirstOrDefaultAsync(id);
            if(post != null)
            {
                return post;
            }
            else
            {
                throw new UserFriendlyException("Post Not Found Maybe It's Deleted");
            }
        }
    }
}
