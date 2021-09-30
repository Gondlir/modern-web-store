using System;

namespace Store.Domain.Queries
{
    public class CustomerQueryResult
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }

    }
}
