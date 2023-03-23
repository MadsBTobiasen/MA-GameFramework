using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects
{
    /// <summary>
    /// Interface to be added to ingame-objects.
    /// </summary>
    public interface IItemObject : IIdentity<int>
    {

        /// <summary>
        /// Id tracker for adding id's to objects.
        /// </summary>
        protected static int _itemObjectsIds = 0;

    }
}
