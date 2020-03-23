using System;

namespace Entities.FatherEntity
{
    public class Entity
    {

        public Entity()
        {
            ID = new Guid();
            IsActive = true;
            
        }

        public Guid ID { get; set; }
        public bool IsActive { get; set; }

        public void ChangeState(bool state)
        {
            this.IsActive = state;
        }
    }
}
