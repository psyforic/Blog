using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Brenoma.Configuration;
using Brenoma.Web;

namespace Brenoma.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BrenomaDbContextFactory : IDesignTimeDbContextFactory<BrenomaDbContext>
    {
        public BrenomaDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BrenomaDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BrenomaDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BrenomaConsts.ConnectionStringName));

            return new BrenomaDbContext(builder.Options);
        }
    }
}
