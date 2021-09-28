using System;
using System.ComponentModel.DataAnnotations;
using Flunt.Notifications;

namespace Store.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; private set; }
    }
}