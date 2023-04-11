using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    public abstract class Entity : IEntity, IValidate
    {

        #region Fields
        private Position _position;
        #endregion

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get { _position ??= new Position(0, 0); ; return _position; } set { _position = value; } }
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor, to allow for reflection.
        /// </summary>
        public Entity()
        {
            Name = "";
            _position = new Position(0, 0);
        }
        #endregion

        #region Methods
        public virtual void Validate()
        {

            if (Id < 0)
                throw new ArgumentException("Id cannot be less than 0.");

            if (string.IsNullOrEmpty(Name) || Name.Length < 2)
                throw new ArgumentException("Name cannot be null, or less than 2 characters.");

        }
        #endregion

    }
}
