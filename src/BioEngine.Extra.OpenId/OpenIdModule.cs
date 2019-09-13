using System;
using BioEngine.Core.Abstractions;
using BioEngine.Core.DB;
using BioEngine.Core.Modules;
using BioEngine.Core.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BioEngine.Extra.OpenId
{
    public abstract class OpenIdModule<TConfig, TUser, TUserDataProvider> : BaseUsersModule<TConfig, TUser,
        TUserDataProvider, OpenIdCurrentUserProvider<TUser>>
        where TConfig : OpenIdModuleConfig where TUserDataProvider : class, IUserDataProvider where TUser : IUser, new()
    {
    }

    public abstract class OpenIdModuleConfig : BaseUsersModuleConfig
    {
        public Uri ServerUri { get; }

        public OpenIdModuleConfig(Uri serverUri)
        {
            ServerUri = serverUri;
        }
    }
}
