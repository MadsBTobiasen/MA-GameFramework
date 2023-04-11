using MA_GameFramework.Objects.Entities;
using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework
{
    public class World
    {

        #region Properties
        /// <summary>
        /// Max width of the world.
        /// </summary>
        public int MaxX { get; private set; }
        /// <summary>
        /// Max height of the world.
        /// </summary>
        public int MaxY { get; private set; }
        /// <summary>
        /// Creatures present in the World.
        /// </summary>
        public ObjectStore<Creature> Creatures { get; private set; }
        /// <summary>
        /// WorldObjects in the World.
        /// </summary>
        public ObjectStore<WorldObject> WorldObjects { get; private set; }
        /// <summary>
        /// ItemObjects available in the Game.
        /// </summary>
        public ObjectStore<Item> ItemObjects { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of a World.
        /// </summary>
        /// <param name="maxX">MaxX of the World.</param>
        /// <param name="maxY">MaxY of the World.</param>
        /// <param name="creatures">Creatures present in the World.</param>
        /// <param name="worldObjects">WorldObject present in the World.</param>
        public World(int maxX, int maxY, ObjectStore<Creature> creatures, ObjectStore<WorldObject> worldObjects, ObjectStore<Item> itemObjects)
        {
        
            MaxX = maxX;
            MaxY = maxY;
            Creatures = creatures;
            WorldObjects = worldObjects;
            ItemObjects = itemObjects;
      
        }
        public World() { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"World: ({MaxX}x{MaxY}) {Creatures.Length}-Creatures {WorldObjects.Length}-Objects {ItemObjects.Length}-Items";
        }
        #endregion

    }
}
