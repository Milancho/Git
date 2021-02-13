using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Micro.EntityFrameworkCore;
using Micro.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Micro.Web.Tests
{
    [DependsOn(
        typeof(MicroWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MicroWebTestModule : AbpModule
    {
        public MicroWebTestModule(MicroEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MicroWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MicroWebMvcModule).Assembly);
        }
    }
}