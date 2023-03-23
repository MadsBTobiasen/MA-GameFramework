using MA_GameFramework.Objects.WorldObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects
{
    /// <summary>
    /// Interface to be added to WorldObjects.
    /// </summary>
    public interface IWorldObject : IIdentity<int>
    {

        /// <summary>
        /// Id tracker for adding id's to objects.
        /// </summary>
        protected static int _worldObjectsIds = 0;

        /// <summary>
        /// Function that returns the current position of the object in the world map.
        /// </summary>
        /// <returns>Current Position.</returns>
        public Position GetPosition();

    }
}
