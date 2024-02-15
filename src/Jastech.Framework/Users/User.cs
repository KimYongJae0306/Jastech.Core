using Newtonsoft.Json;

namespace Jastech.Framework.Users
{
    public class User
    {
        [JsonProperty]
        public string Id { get; set; }

        [JsonProperty]
        public AuthorityType Type { get; set; }

        [JsonProperty]
        public string Password { get; set; }

        public User()
        {

        }

        public User(string id, string password, AuthorityType type)
        {
            Id = id;
            Password = password;
            Type = type;
        }

        public User(AuthorityType type, string password)
        {
            Id = type.ToString();
            Password = password;
            Type = type;
        }

        public User DeepCopy()
        {
            return new User(Id, Password, Type);
        }
    }

    public enum AuthorityType
    {
        Operator, // DefaultType 이므로 1개만 생성해야한다.
        Engineer,
        Maker,
    }
}
