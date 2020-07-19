using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Brenoma.Authors
{
    public class AuthorManager : IAuthorManager
    {
        private readonly IRepository<Author, Guid> _authorRepository;

        public AuthorManager(IRepository<Author, Guid> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        public async Task CreateAsync(Author author)
        {
            await _authorRepository.InsertAsync(author);
        }

        public async Task<Author> GetAsync(Guid id)
        {
            var author = await _authorRepository.FirstOrDefaultAsync(id);
            if (author != null)
            {
                return author;
            }
            else
            {
                throw new UserFriendlyException("User Not Found, Maybe It's Deleted");
            }
        }
    }
}
