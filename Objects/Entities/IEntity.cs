using MA_GameFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    /// <summary>
    /// Interface for Entities that exist in the game.
    /// </summary>
    public interface IEntity : IIdentity<int>
    {

        /// <summary>
        /// Position of an entity.
        /// </summary>
        Position Position { get; set; }

    }
}
