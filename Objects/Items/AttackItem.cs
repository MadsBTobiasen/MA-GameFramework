using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MA_GameFramework.Objects.Items
{
    public class AttackItem : Item
    {

        #region Static Fields
        /// <summary>
        /// DefaultWeapon.
        /// </summary>
        public static AttackItem Default = new AttackItem() { Id = 9001, Name = "Unarmed", AttackDamage = 0, Range = 1 };
        #endregion

        #region Properties
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
        /// Default Constructor to allow for reflection.
        /// </summary>
        public AttackItem() : base()
        { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"AttackItem: ({Id}) {Name} {AttackDamage} {Range}";
        }
        #endregion

    }
}
