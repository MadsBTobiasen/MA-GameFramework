using MA_GameFramework.Objects.Entities.States;
using MA_GameFramework.Objects.Entities.States.StateFacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    /// <summary>
    /// IMoveable interface, where T defines what kind of input handles the move.
    /// </summary>
    /// <typeparam name="T">T to indicate what moves the object.</typeparam>
    public interface IControllable : Utilities.Interfaces.IObserver<ConsoleKey>
    {

        #region Properties
        /// <summary>
        /// ConsoleKey for moving forward.
        /// </summary>
        public ConsoleKey MoveForward { get; }
        /// <summary>
        /// ConsoleKey for moving forward.
        /// </summary>
        public ConsoleKey MoveBackward { get; }
        /// <summary>
        /// ConsoleKey for moving forward.
        /// </summary>
        public ConsoleKey TurnRight { get; }
        /// <summary>
        /// ConsoleKey for moving forward.
        /// </summary>
        public ConsoleKey TurnLeft { get; }
        /// <summary>
        /// State for determing the direction.
        /// </summary>
        public IState<Moves, bool> StateFacing { get; }
        /// <summary>
        /// Returns a List of Keys used by the object.
        /// </summary>
        public List<ConsoleKey> Keys { get; }
        #endregion

    }
}
