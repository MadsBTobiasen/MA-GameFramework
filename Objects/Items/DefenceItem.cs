using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Items
{
    public class DefenceItem : Item
    {

        #region Static Fields
        /// <summary>
        /// DefaultWeapon.
        /// </summary>
        public static DefenceItem Default = new DefenceItem() { Id = 8001, Name = "No Shield", DefenceRating = 0 };
        #endregion

        #region Properties
        /// <summary>
        /// DefenceRating of the DefenceItem.
        /// </summary>
        public int DefenceRating { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor, to allow for reflection.
        /// </summary>
        public DefenceItem() : base()
        { }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"DefenceItem: ({Id}) {Name} {DefenceRating}";
        }
        #endregion

    }
}
