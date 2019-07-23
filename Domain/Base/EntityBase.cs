using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Base
{
    public abstract class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public override bool Equals(object obj)
        {
            var other = obj as EntityBase;

            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            if (this.GetType() != obj.GetType())
                return false;
            if (this.Id == Guid.Empty || other.Id == Guid.Empty)
                return false;
            return this.Id == other.Id;
        }

        public static bool operator ==(EntityBase entity1, EntityBase entity2)
        {
            if (ReferenceEquals(entity1, null) && ReferenceEquals(entity2, null))
                return true;
            if (ReferenceEquals(entity1, null) || ReferenceEquals(entity2, null))
                return false;
            return entity1.Equals(entity2);
        }

        public static bool operator !=(EntityBase entity1, EntityBase entity2)
        {
            return !(entity1 == entity2);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Id).GetHashCode();
        }
    }
}
