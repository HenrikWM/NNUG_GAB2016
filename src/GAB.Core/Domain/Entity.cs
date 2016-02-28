using System;

namespace GAB.Core.Domain
{
    public abstract class Entity
    {
        protected virtual Guid Id { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}