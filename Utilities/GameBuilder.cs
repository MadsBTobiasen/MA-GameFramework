using MA_GameFramework.Controllers;
using MA_GameFramework.Objects.Entities;
using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities.XmlBuilders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities
{
    /// <summary>
    /// GameBuilder object.
    /// </summary>
    /// <typeparam name="TControl">Type to control the game with.</typeparam>
    public class GameBuilder<TControl> where TControl : struct
    {

        #region Fields
        private InputController<TControl> _inputController;
        private MovementController _movementController;
        #endregion

        #region Properties
        public WorldBuilder WorldBuilder { get; private set; }
        #endregion

        #region Constructor
        public GameBuilder()
        {

            _inputController = new InputController<TControl>();
            _movementController = new MovementController();

            WorldBuilder = new WorldBuilder();

            _inputController.AddObservers(_movementController);

        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that adds Entities that can move in the World.
        /// </summary>
        /// <returns></returns>
        public GameBuilder<TControl> AddControllables<T>(params T[] controllables) where T : Creature, IControllable
        {

            WorldBuilder.AddCreatures(controllables);
            _movementController.AddObservers(controllables);
            controllables.ToList().ForEach(c => _movementController.AddKeys(c.Keys.ToArray()));

            return this;
        }

        /// <summary>
        /// Method that builds the game, and returns the game-object.
        /// </summary>
        /// <returns></returns>
        public Game<TControl> Build()
        {
            return new Game<TControl>( WorldBuilder.Build(true), _inputController );
        }
        #endregion

    }

}
