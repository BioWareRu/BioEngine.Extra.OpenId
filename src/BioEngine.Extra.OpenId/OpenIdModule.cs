using System;
using BioEngine.Core.Abstractions;
using BioEngine.Core.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.Extra.OpenId
{
    public abstract class OpenIdModule<TConfig> : BaseBioEngineModule<TConfig> where TConfig : OpenIdModuleConfig
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<IUserDataProvider, OpenIdUserDataProvider>();
            services.AddScoped<ICurrentUserProvider, OpenIdCurrentUserProvider>();
        }
    }

    public abstract class OpenIdModuleConfig
    {
        public Uri ServerUri { get; }

        public OpenIdModuleConfig(Uri serverUri)
        {
            ServerUri = serverUri;
        }
    }
}
