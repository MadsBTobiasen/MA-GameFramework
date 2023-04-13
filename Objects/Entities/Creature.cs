using MA_GameFramework.Objects.Items;
using MA_GameFramework.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    /// <summary>
    /// Class that defines a creature in the world space.
    /// </summary>
    public class Creature : Entity, IValidate
    {

        #region Fields
        private AttackItem _weapon;
        private DefenceItem _shield;
        #endregion

        #region Properties
        /// <summary>
        /// Hitpoints of the Creature.
        /// </summary>
        public int Hitpoints { get; set; }
        /// <summary>
        /// The weapon the Creature is using.
        /// </summary>
        public AttackItem Weapon { get { if (_weapon == null || _weapon.Id == -1) return AttackItem.Default; else return _weapon; } set { _weapon = value; } }
        /// <summary>
        /// The shield the Creature is using.
        /// </summary>
        public DefenceItem Shield { get { if (_weapon == null || _shield.Id == -1) return DefenceItem.Default; else return _shield; } set { _shield = value; } }
        /// <summary>
        /// Boolean indicating if the creature is dead or alive.
        /// </summary>
        public bool IsAlive => Hitpoints >= 0;
        #endregion

        #region Constructors
        /// <summary>
        /// Default Constructor to allow for reflection.
        /// </summary>
        public Creature() : base()
        { 
            
        }
        #endregion

        #region Methods
        public override void Validate() 
        {

            base.Validate();
            if (Hitpoints < 0)
                throw new ArgumentException("Hitpoints cannot be less than 0.");

        }

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

        public override string ToString()
        {
            return $"Creature: ({Id}) {Name} {Hitpoints} | {Position} | {Weapon} | {Shield}";
        }
        #endregion

    }
}
