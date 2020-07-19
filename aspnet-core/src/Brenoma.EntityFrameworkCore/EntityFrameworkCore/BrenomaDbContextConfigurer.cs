using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Brenoma.EntityFrameworkCore
{
    public static class BrenomaDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BrenomaDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BrenomaDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
