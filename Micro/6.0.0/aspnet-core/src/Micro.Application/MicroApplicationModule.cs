using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Micro.Authorization;

namespace Micro
{
    [DependsOn(
        typeof(MicroCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MicroApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MicroAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MicroApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
