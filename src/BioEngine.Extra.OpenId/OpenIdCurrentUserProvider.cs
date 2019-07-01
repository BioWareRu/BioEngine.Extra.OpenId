using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BioEngine.Core.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace BioEngine.Extra.OpenId
{
    public class OpenIdCurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IUser CurrentUser =>
            new User
            {
                Id =
                    _httpContextAccessor.HttpContext.User.Claims
                        .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value,
                Name =
                    _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)
                        ?.Value,
                PhotoUrl =
                    _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "photo")?.Value,
                ProfileUrl = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == ClaimTypes.Webpage)?.Value
            };

        public OpenIdCurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<string> GetAccessTokenAsync()
        {
            return _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        }
    }
}
