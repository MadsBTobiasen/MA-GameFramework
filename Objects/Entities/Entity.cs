using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    public abstract class Entity : IEntity
    {

        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Default Constructor, to allow for reflection.
        /// </summary>
        public Entity()
        {
            Name = "";
            Position = new Position(0, 0);
        }
        #endregion

    }
}
