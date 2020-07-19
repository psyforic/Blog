using Abp.Domain.Entities.Auditing;
using Brenoma.Authors;
using Brenoma.Categories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Brenoma.Posts
{
    [Table("AppPosts")]
    public class Post : FullAuditedEntity<Guid>
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public Guid? AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }


        public static Post Create(string title, string body, Guid? authorId, Guid categoryId)
        {
            var post = new Post
            {
                Title = title,
                Body = body,
                AuthorId = authorId,
                CategoryId = categoryId
            };
            return post;
        }

    }
}
