using Abp.Domain.Entities.Auditing;
using Brenoma.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Brenoma.Categories
{
    [Table("AppCategories")]
    public class Category : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
