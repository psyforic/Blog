using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Brenoma.Authorization.Roles;
using Brenoma.Authorization.Users;
using Brenoma.MultiTenancy;
using Brenoma.Posts;
using Brenoma.Authors;
using Brenoma.Categories;

namespace Brenoma.EntityFrameworkCore
{
    public class BrenomaDbContext : AbpZeroDbContext<Tenant, Role, User, BrenomaDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Post> Posts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }



        public BrenomaDbContext(DbContextOptions<BrenomaDbContext> options)
            : base(options)
        {
        }
    }
}
