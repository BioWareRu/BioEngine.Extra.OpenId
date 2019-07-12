using System;
using System.Collections.Generic;
using System.Security.Claims;
using BioEngine.Core.Api.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.Extra.OpenId.Api
{
    public class ApiOpenIdModule : OpenIdModule<ApiOpenIdModuleConfig>
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
            services.AddAuthorization(options =>
            {
                options.AddPolicy(BioPolicies.Admin,
                    builder => builder.RequireAuthenticatedUser().RequireClaim(ClaimTypes.Role, "admin"));
                options.AddPolicy(BioPolicies.User, builder => builder.RequireAuthenticatedUser());
                foreach (var policy in Config.Policies)
                {
                    options.AddPolicy(policy.Key, policy.Value);
                }
            });
        }
    }

    public class ApiOpenIdModuleConfig : OpenIdModuleConfig
    {
        public string Audience { get; }
        public Dictionary<string, AuthorizationPolicy> Policies { get; }

        public ApiOpenIdModuleConfig(Uri serverUri, string audience, Dictionary<string, AuthorizationPolicy> policies) :
            base(serverUri)
        {
            Audience = audience;
            Policies = policies;
        }
    }
}
