using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.Core.Abstractions;

namespace BioEngine.Extra.OpenId
{
    public class OpenIdUserDataProvider : IUserDataProvider
    {
        public Task<List<IUser>> GetDataAsync(string[] userIds)
        {
            return Task.FromResult(new List<IUser>());
        }
    }
}
