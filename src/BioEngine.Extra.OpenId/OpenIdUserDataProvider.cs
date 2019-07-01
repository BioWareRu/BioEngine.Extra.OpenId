using System.Collections.Generic;
using System.Threading.Tasks;
using BioEngine.Core.Abstractions;

namespace BioEngine.Extra.OpenId
{
    public class OpenIdUserDataProvider : IUserDataProvider
    {
        public Task<List<IUser>> GetDataAsync(string[] userIds)
        {
            throw new System.NotImplementedException();
        }
    }
}
