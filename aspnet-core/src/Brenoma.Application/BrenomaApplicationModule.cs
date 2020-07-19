using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Brenoma.Authorization;

namespace Brenoma
{
    [DependsOn(
        typeof(BrenomaCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BrenomaApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BrenomaAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BrenomaApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
