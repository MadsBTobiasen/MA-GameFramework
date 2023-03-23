using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.WorldObjects
{
    /// <summary>
    /// Class that defines an object in the world space.
    /// </summary>
    public class WorldObject : IWorldObject
    {

        #region Fields
        /// <summary>
        /// Position object of the WorldObject.
        /// </summary>
        private Position _position;
        #endregion

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Name of the WorldObject.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Boolean to indicate whether it's lootable or not.
        /// </summary>
        public bool Lootable { get; private set; }
        /// <summary>
        /// Boolean to indicate whether it's removeable or not.
        /// </summary>
        public bool Removable { get; private set; }
        #endregion

        #region Constructors
        public WorldObject(string name)
        {
            Name = name;
            _position = new Position(0, 0);
        }
        #endregion

        #region Methods
        public Position GetPosition()
        {
            return _position;
        }
        #endregion

    }
}
