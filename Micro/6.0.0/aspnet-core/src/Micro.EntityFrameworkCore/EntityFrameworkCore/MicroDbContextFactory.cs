using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Micro.Configuration;
using Micro.Web;

namespace Micro.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MicroDbContextFactory : IDesignTimeDbContextFactory<MicroDbContext>
    {
        public MicroDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MicroDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MicroDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MicroConsts.ConnectionStringName));

            return new MicroDbContext(builder.Options);
        }
    }
}
