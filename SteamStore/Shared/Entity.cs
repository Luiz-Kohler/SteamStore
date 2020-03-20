using System;

namespace Shared
{
    public class Entity
    {

        public Entity()
        {
            Id = new Guid();
            IsActive = true;
            
        }

        public Guid Id { get; set; }
        public bool IsActive { get; set; }

        public void ChangeState(bool state)
        {
            this.IsActive = state;
        }
    }
}
