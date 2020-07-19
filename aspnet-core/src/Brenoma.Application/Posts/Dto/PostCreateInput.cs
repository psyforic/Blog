using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Brenoma.Posts.Dto
{
    [AutoMapTo(typeof(Post))]
    public class PostCreateInput
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
