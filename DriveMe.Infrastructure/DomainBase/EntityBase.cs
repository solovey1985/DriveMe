using System;
using System.ComponentModel.DataAnnotations;

namespace DriveMe.Infrastructure
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
    public abstract class EntityBase:IEntity
    {
        private Guid id;
        public State State { get; set; }
        /// < summary>
        ///     Default Constructor.
        /// </summary>
        protected EntityBase()
        {}

        /// < summary>
        ///     Overloaded constructor.
        /// </summary>
        /// < param name="key">
        ///     An < see cref="System.Object" /> that
        ///     represents the primary identifier value for the
        ///     class.
        /// </param>
        protected EntityBase(Guid id)
        {
            this.id = id;
        }

        /// < summary>
        ///     An < see cref="System.Object" /> that represents the
        ///     primary identifier value for the class.
        /// </summary>
        public Guid Id { get { return id; } set { id = value; } }

        #region Equality Tests

        /// < summary >
        /// Determines whether the specified entity is equal to the
        /// current instance.
        /// </summary >
        /// < param name="entity" > An < see cref="System.Object"/> that
        /// will be compared to the current instance. </param >
        /// < returns > True if the passed in entity is equal to the
        /// current instance. </returns >
        public override bool Equals(object entity)
        {
            if (entity == null || !(entity is EntityBase))
            {
                return false;
            }
            return (this == (EntityBase) entity);
        }

        /// < summary >
        /// Operator overload for determining equality.
        /// </summary >
        /// < param name="base1" > The first instance of an
        /// < see cref="EntityBase"/> . </param >
        /// < param name="base2" > The second instance of an
        /// < see cref="EntityBase"/> . </param >
        /// < returns > True if equal. </returns >
        public static bool operator ==(EntityBase base1,
            EntityBase base2)
        {
            // check for both null (cast to object or recursive loop)
            if ((object) base1 == null && (object) base2 == null)
            {
                return true;
            }
            // check for either of them == to null
            if ((object) base1 == null || (object) base2 == null)
            {
                return false;
            }
            if (base1.Id == base2.Id)

            {
                return true;
            }
            return true;
        }

        /// < summary >
        /// Operator overload for determining inequality.
        /// </summary >
        /// < param name="base1" > The first instance of an
        /// < see cref="EntityBase"/> . </param >
        /// < param name="base2" > The second instance of an
        /// < see cref="EntityBase"/> . </param >
        /// < returns > True if not equal. </returns >
        public static
            bool operator !=(EntityBase base1,
                EntityBase base2)
        {
            return (!(
                base1 == base2));
        }

        /// < summary >
        /// Serves as a hash function for this type.
        /// </summary >
        /// < returns > A hash code for the current Key
        /// property. </returns >
        public override int GetHashCode()
        {
            return this.id.GetHashCode();
        }

        #endregion

        #region Validate
        protected abstract void Validate();

        #endregion
    }

    public enum State
    {
        Added,
        Modified,
        Removed,
        Not
    }

}


 