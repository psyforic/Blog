using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Brenoma.EntityFrameworkCore;
using Brenoma.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Brenoma.Web.Tests
{
    [DependsOn(
        typeof(BrenomaWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BrenomaWebTestModule : AbpModule
    {
        public BrenomaWebTestModule(BrenomaEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrenomaWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BrenomaWebMvcModule).Assembly);
        }
    }
}