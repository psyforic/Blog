using Abp.Domain.Entities.Auditing;
using Brenoma.Posts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Brenoma.Authors
{
    [Table("AppAuthors")]
    public class Author : FullAuditedEntity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
