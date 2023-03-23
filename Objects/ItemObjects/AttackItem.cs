using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MA_GameFramework.Objects.ItemObjects
{
    public class AttackItem : IItemObject
    {

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Name of the weapon.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// AttackDamage of the Weapon.
        /// </summary>
        public int AttackDamage { get; set; }
        /// <summary>
        /// Range of the weapon.
        /// </summary>
        public int Range { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of AttackItem.
        /// </summary>
        /// <param name="damage">How much damage the weapon will deal.</param>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="range">THe range of the weapon.</param>
        public AttackItem(string name, int damage, int range)
        {
            Name = name;
            AttackDamage = damage;
            Range = range;
        }

        /// <summary>
        /// Default Constructor to allow for reflection.
        /// </summary>
        public AttackItem()
        {
            Name = "";
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"AttackItem: ({Id}) {Name} {AttackDamage} {Range}";
        }
        #endregion

    }
}
