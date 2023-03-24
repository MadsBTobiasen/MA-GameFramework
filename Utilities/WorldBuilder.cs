using MA_GameFramework.Objects.Entities;
using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities.XmlBuilders;
using MA_GameFramework.Utilities.XMLBuilders;
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
        private List<IItem> _items;
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
            _items = new List<IItem>();
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

        #region Creature Adders
        /// <summary>
        /// Function that adds the Creature to the World.
        /// </summary>
        /// <param name="creature">Creature to add.</param>
        public void AddCreatures(params Creature[] creatures)
        {
            _creatures.AddRange(creatures);
        }

        /// <summary>
        /// Function that adds Creatures to the World, 
        /// from a .XML file, given by the path.
        /// </summary>
        /// <param name="path">Path to the creatures .XML.</param>
        public void AddCreatureFromXml(string path)
        {
            _creatures.AddRange(EntityXmlBuilder<Creature>.Build<Creature>(path));
        }

        //ADD COMMENT
        public void AddCreatureFromXml<T>(string path) where T : Creature, new()
        {
            _creatures.AddRange(EntityXmlBuilder<Creature>.Build<T>(path));
        }
        #endregion

        #region WorldObject Adders
        /// <summary>
        /// Function that adds the WorldObject to the World.
        /// </summary>
        /// <param name="worldObject">World to add.</param>
        public void AddWorldObjects(params WorldObject[] worldObjects)
        {
            _worldObjects.AddRange(worldObjects);
        }

        /// <summary>
        /// Function that adds WorldObjects to the World, 
        /// from a .XML file, given by the path.
        /// </summary>
        /// <param name="path">Path to the worldObjects .XML.</param>
        public void AddWorldObjectsFromXml(string path)
        {
            _worldObjects.AddRange(EntityXmlBuilder<WorldObject>.Build<WorldObject>(path));
        }

        // ADD COMMENT
        public void AddWorldObjectsFromXml<T>(string path) where T : WorldObject, new()
        {
            _worldObjects.AddRange(EntityXmlBuilder<WorldObject>.Build<T>(path));
        }
        #endregion

        #region Item Adders
        /// <summary>
        /// Function that adds the Items to the World.
        /// </summary>
        public void AddItems(params IItem[] items)
        {
            _items.AddRange(items);
        }

        /// <summary>
        /// Function that adds Items to the World, 
        /// from a .XML file, given by the path.
        /// </summary>
        /// <param name="path">Path to the items .XML.</param>
        public void AddItemsFromXml<T>(string path) where T : Item, new()
        {
            _items.AddRange(ItemXmlBuilder<Item>.Build<T>(path));
        }
        #endregion

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

            ObjectStore<IItem> itemsStore = new ObjectStore<IItem>();
            itemsStore.Add(_items.OrderByDescending(i => i.Id));

            return new World(_worldSizeX, _worldSizeY, creatureStore, worldObjectsStore, itemsStore);
        
        }
        #endregion

    }

}
