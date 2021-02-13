using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Micro.Authorization.Roles;
using Micro.Authorization.Users;
using Micro.MultiTenancy;
using Micro.Tasks;

namespace Micro.EntityFrameworkCore
{
    public class MicroDbContext : AbpZeroDbContext<Tenant, Role, User, MicroDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Task> Tasks { get; set; }

        public MicroDbContext(DbContextOptions<MicroDbContext> options)
            : base(options)
        {
        }
    }
}
