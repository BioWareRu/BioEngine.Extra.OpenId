using System;
using BioEngine.Core.Abstractions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.Extra.OpenId.Api
{
    public class
        ApiOpenIdModule<TUser, TUserDataProvider> : OpenIdModule<ApiOpenIdModuleConfig, TUser, TUserDataProvider>
        where TUser : IUser, new() where TUserDataProvider : class, IUserDataProvider
    {
        public override void ConfigureServices(IServiceCollection services, IConfiguration configuration,
            IHostEnvironment environment)
        {
            base.ConfigureServices(services, configuration, environment);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = Config.ServerUri.ToString();
                options.Audience = Config.Audience;
                options.RequireHttpsMetadata = !environment.IsDevelopment();
            });
        }
    }

    public class ApiOpenIdModuleConfig : OpenIdModuleConfig
    {
        public string Audience { get; }

        public ApiOpenIdModuleConfig(Uri serverUri, string audience) :
            base(serverUri)
        {
            Audience = audience;
        }
    }
}
