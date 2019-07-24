using BioEngine.Core.Abstractions;
using BioEngine.Core.DB;

namespace BioEngine.Extra.OpenId
{
    [Entity("openiduser")]
    public class User : IUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string ProfileUrl { get; set; }

        public string GetId()
        {
            return Id;
        }
    }
}
