using System;
using BioEngine.Core.Abstractions;
using BioEngine.Core.DB;
using BioEngine.Core.Modules;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.Extra.OpenId
{
    public abstract class OpenIdModule<TConfig, TUser, TUserDataProvider> : BaseBioEngineModule<TConfig>
        where TConfig : OpenIdModuleConfig where TUserDataProvider : class, IUserDataProvider where TUser : IUser, new()
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddScoped<IUserDataProvider, TUserDataProvider>();
            services.AddScoped<ICurrentUserProvider, OpenIdCurrentUserProvider<TUser>>();
        }

        public override void ConfigureEntities(IServiceCollection serviceCollection, BioEntitiesManager entitiesManager)
        {
            base.ConfigureEntities(serviceCollection, entitiesManager);
            RegisterRepositories(typeof(TUser).Assembly, serviceCollection, entitiesManager);
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
