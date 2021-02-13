using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Micro.EntityFrameworkCore
{
    public static class MicroDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MicroDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MicroDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
