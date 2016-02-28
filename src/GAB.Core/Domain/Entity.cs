using System;

namespace GAB.Core.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; internal set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}