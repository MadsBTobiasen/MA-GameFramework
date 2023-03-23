using MA_GameFramework.Objects;
using MA_GameFramework.Objects.WorldObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities
{
    /// <summary>
    /// WorldBuilder class, where objects and creatures, can be added, before being returned.
    /// </summary>
    public class WorldBuilder
    {

        #region Fields
        private List<Creature> _creatures;
        private List<WorldObject> _worldObjects;
        private List<IItemObject> _items;
        private int _worldSizeX, _worldSizeY;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of WorldBuilder.
        /// </summary>
        public WorldBuilder()
        {
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
            _items = new List<IItemObject>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Function that sets the size of the World.
        /// </summary>
        /// <param name="maxX">MaxX of the world.</param>
        /// <param name="maxY">MaxY of the world.</param>
        public void SetDimensions(int maxX, int maxY)
        {
            _worldSizeX = maxX;
            _worldSizeY = maxY;
        }

        /// <summary>
        /// Function that adds the Creature to the World.
        /// </summary>
        /// <param name="creature">Creature to add.</param>
        public void AddCreature(params Creature[] creatures)
        {
            _creatures.AddRange(creatures);
        }

        /// <summary>
        /// Function that adds the WorldObject to the World.
        /// </summary>
        /// <param name="worldObject">World to add.</param>
        public void AddObject(params WorldObject[] worldObjects)
        {
            _worldObjects.AddRange(worldObjects);
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddItem(params IItemObject[] items)
        {
            _items.AddRange(items);
        }

        /// <summary>
        /// Function that creates the World, and returns it.
        /// </summary>
        /// <returns>Instance of World.</returns>
        public World Build()
        {

            ObjectStore<Creature> creatureStore = new ObjectStore<Creature>();
            creatureStore.Add(_creatures.OrderByDescending(c => c.Id));

            ObjectStore<WorldObject> worldObjectsStore = new ObjectStore<WorldObject>();
            worldObjectsStore.Add(_worldObjects.OrderByDescending(w => w.Id));

            ObjectStore<IItemObject> itemsStore = new ObjectStore<IItemObject>();
            itemsStore.Add(_items.OrderByDescending(i => i.Id));

            return new World(_worldSizeX, _worldSizeY, creatureStore, worldObjectsStore, itemsStore);
        
        }
        #endregion

    }

}
