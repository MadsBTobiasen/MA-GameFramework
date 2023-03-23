using MA_GameFramework.Objects.ItemObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.WorldObjects
{
    /// <summary>
    /// Class that defines a creature in the world space.
    /// </summary>
    public class Creature : IWorldObject
    {

        #region Fields
        /// <summary>
        /// Position object for the creature.
        /// </summary>
        private Position _position;
        #endregion

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Name of the Creature.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Hitpoints of the Creature.
        /// </summary>
        public int Hitpoints { get; private set; }
        /// <summary>
        /// The weapon the Creature is using.
        /// </summary>
        public AttackItem Weapon { get; private set; }
        /// <summary>
        /// The shield the Creature is using.
        /// </summary>
        public DefenceItem Shield { get; private set; }
        /// <summary>
        /// Boolean indicating if the creature is dead or alive.
        /// </summary>
        public bool IsAlive => Hitpoints >= 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Create a new instance of the creature.
        /// </summary>
        /// <param name="name"></param>
        public Creature(string name)
        {
            
            _position = new Position(0, 0);

            Name = name;
            Hitpoints = 0;

        }
        /// <summary>
        /// Create a new instance of the creature.
        /// </summary>
        /// <param name="startX">Starting X-Position of the Creature.</param>
        /// <param name="startY">Starting X-Position of the Creature.</param>
        /// <param name="name">Name of the Creature.</param>
        /// <param name="hitpoints">Starting hitpoints of the creature.</param>
        public Creature(int startX, int startY, string name, int hitpoints, AttackItem aItem, DefenceItem dItem)
        {

            _position = new Position(startX, startY);

            Name = name;
            Hitpoints = hitpoints;

            Weapon = aItem;
            Shield = dItem;

        }
        #endregion

        #region Methods
        /// <summary>
        /// Function that returns the damage the creature deals.
        /// </summary>
        /// <returns>Damage dealt.</returns>
        public int DealDamage()
        {
            return Weapon.AttackDamage;
        }

        /// <summary>
        /// Function that applies damage to the creature.
        /// </summary>
        /// <param name="damage">Damage to receive.</param>
        /// <returns>Boolean to indicate is creature is alive or not.</returns>
        public bool ReceiveHit(int damage)
        {
            Hitpoints -= Shield.DefenceRating - damage;
            return IsAlive;
        }

        public Position GetPosition()
        {
            return _position;
        }
        #endregion

    }
}
