using MA_GameFramework.Objects.Entities;
using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities.XMLBuilders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private List<Item> _items;
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
            _items = new List<Item>();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Function that sets the size of the World.
        /// </summary>
        /// <param name="maxX">MaxX of the world.</param>
        /// <param name="maxY">MaxY of the world.</param>
        public WorldBuilder SetDimensions(int maxX, int maxY)
        {
            _worldSizeX = maxX;
            _worldSizeY = maxY;
            return this;
        }

        #region Creature Adders
        /// <summary>
        /// Function that adds the Creature to the World.
        /// </summary>
        /// <param name="creature">Creature to add.</param>
        public WorldBuilder AddCreatures(params Creature[] creatures)
        {
            _creatures.AddRange(creatures);
            return this;
        }

        /// <summary>
        /// Function that adds Creatures to the World, 
        /// from a .XML file, given by the path.
        /// </summary>
        /// <param name="path">Path to the creatures .XML.</param>
        public WorldBuilder AddCreatureFromXml(string path)
        {
            _creatures.AddRange(CreatureXmlBuilder<Creature>.Build<Creature>(path));
            return this;
        }

        /// <summary>
        /// Functions that adds Creatures to the World,
        /// from a .XML file, given by the path, and a dervied type of Creature.
        /// </summary>
        /// <typeparam name="T">Derived type of Creatures.</typeparam>
        /// <param name="path">Path to the object.</param>
        public WorldBuilder AddCreatureFromXml<T>(string path) where T : Creature, new()
        {
            _creatures.AddRange(CreatureXmlBuilder<Creature>.Build<T>(path));
            return this;
        }
        #endregion

        #region WorldObject Adders
        /// <summary>
        /// Function that adds the WorldObject to the World.
        /// </summary>
        /// <param name="worldObject">World to add.</param>
        public WorldBuilder AddWorldObjects(params WorldObject[] worldObjects)
        {
            _worldObjects.AddRange(worldObjects);
            return this;
        }

        /// <summary>
        /// Function that adds WorldObjects to the World, 
        /// from a .XML file, given by the path.
        /// </summary>
        /// <param name="path">Path to the worldObjects .XML.</param>
        public WorldBuilder AddWorldObjectsFromXml(string path)
        {
            _worldObjects.AddRange(WorldObjectXmlBuilder<WorldObject>.Build<WorldObject>(path));
            return this;
        }

        /// <summary>
        /// Functions that adds WorldObjects to the World,
        /// from a .XML file, given by the path, and a dervied type of WorldObject.
        /// </summary>
        /// <typeparam name="T">Derived type of WorldObject.</typeparam>
        /// <param name="path">Path to the object.</param>
        public WorldBuilder AddWorldObjectsFromXml<T>(string path) where T : WorldObject, new()
        {
            _worldObjects.AddRange(WorldObjectXmlBuilder<WorldObject>.Build<T>(path));
            return this;
        }
        #endregion

        #region Item Adders
        /// <summary>
        /// Function that adds the Items to the World.
        /// </summary>
        public WorldBuilder AddItems(params Item[] items)
        {
            _items.AddRange(items);
            return this;
        }

        /// <summary>
        /// Function that adds Items to the World, 
        /// from a .XML file, given by the path.
        /// </summary>
        /// <param name="path">Path to the items .XML.</param>
        public WorldBuilder AddItemsFromXml<T>(string path) where T : Item, new()
        {
            _items.AddRange(ItemXmlBuilder<Item>.Build<T>(path));
            return this;
        }
        #endregion

        /// <summary>
        /// Function that creates the World, and returns it.
        /// </summary>
        /// <param name="randomizePositions">Randomize positions of objects, where positions is 0:0.</param>
        /// <returns>Instance of World.</returns>
        public World Build(bool randomizePositions)
        {

            ObjectStore<Creature> creatureStore = new ObjectStore<Creature>();
            creatureStore.Add(_creatures.OrderByDescending(c => c.Id));
            creatureStore.Items.ForEach(c => c.Validate());
            creatureStore.Items.ForEach(c => c.Position.SetBoundary(_worldSizeX, _worldSizeY));
            TracerListeners.TS.TraceEvent(TraceEventType.Information, 999, $"Created & Validated {creatureStore.Length}-creatures.");

            ObjectStore<WorldObject> worldObjectsStore = new ObjectStore<WorldObject>();
            worldObjectsStore.Add(_worldObjects.OrderByDescending(w => w.Id));
            worldObjectsStore.Items.ForEach(w => w.Validate());
            TracerListeners.TS.TraceEvent(TraceEventType.Information, 999, $"Created & Validated {worldObjectsStore.Length}-creatures.");

            ObjectStore<Item> itemsStore = new ObjectStore<Item>();
            itemsStore.Add(_items.OrderByDescending(i => i.Id));
            itemsStore.Items.ForEach(i => i.Validate());
            TracerListeners.TS.TraceEvent(TraceEventType.Information, 999, $"Created & Validated {itemsStore.Length}-creatures.");

            if(randomizePositions)
            {
                TracerListeners.TS.TraceEvent(TraceEventType.Information, 999, $"Radomized Positions of Entities.");
                creatureStore.Items.ForEach(c =>
                {

                    bool isControllable = c.GetType().GetInterfaces().ToList().Exists(type => type.Name == typeof(IControllable).Name);

                    if(c.Position.X + c.Position.Y <= 0 && !isControllable)
                        c.Position = Position.GetRandom(_worldSizeX, _worldSizeY);
                });
            }

            World world = new World(_worldSizeX, _worldSizeY, creatureStore, worldObjectsStore, itemsStore);
            TracerListeners.TS.TraceEvent(TraceEventType.Information, 999, $"Initialized World: ({world}).");

            return world;

        }
        #endregion

    }

}
