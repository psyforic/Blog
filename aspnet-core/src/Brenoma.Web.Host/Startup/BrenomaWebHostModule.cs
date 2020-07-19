using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Brenoma.Configuration;

namespace Brenoma.Web.Host.Startup
{
    [DependsOn(
       typeof(BrenomaWebCoreModule))]
    public class BrenomaWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BrenomaWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrenomaWebHostModule).GetAssembly());
        }
    }
}
