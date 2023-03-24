using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    /// <summary>
    /// Class that defines an object in the world space.
    /// </summary>
    public class WorldObject : Entity
    {

        #region Properties
        /// <summary>
        /// Boolean to indicate whether it's lootable or not.
        /// </summary>
        public bool Lootable { get; set; }
        /// <summary>
        /// Boolean to indicate whether it's removeable or not.
        /// </summary>
        public bool Removable { get; set; }
        #endregion

        #region Constructors
        public WorldObject() : base()
        {
            Position = new Position(0, 0);
        }
        #endregion

        #region Methods

        #endregion

    }
}
