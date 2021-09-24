using Store.Shared.Entities;

namespace Store.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password)
        {

            Username = username;
            Password = password;
        }


        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true;
        public void Desactivate() => Active = false;

        public override string ToString()
        {
            return $"{Username}";
        }

    }
}