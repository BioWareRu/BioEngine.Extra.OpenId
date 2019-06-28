using BioEngine.Core.Abstractions;

namespace BioEngine.Extra.OpenId
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string ProfileUrl { get; set; }
    }
}
