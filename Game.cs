using MA_GameFramework.Controllers;
using MA_GameFramework.Utilities.GameInputAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework
{
    /// <summary>
    /// Object containing the mechanisms for running the game.
    /// </summary>
    /// <typeparam name="T">Type that determines what input the game engine takes.</typeparam>
    public class Game<T> where T : struct
    {

        #region Fields
        private InputController<T> _inputController;
        #endregion

        #region Properties
        public World World { get; private set; }
        #endregion

        #region Constructor
        public Game(World world, InputController<T> inputController)
        {
            World = world;
            _inputController = inputController;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that performs a game-tick, triggering movement of objects.
        /// </summary>
        /// <param name="input">Input for a game tick.</param>
        public void Tick(T? input)
        {

            if (input == null)
                return;

            _inputController.HandleInput(input.Value);

            World.Update();

        }
        #endregion

    }
}
