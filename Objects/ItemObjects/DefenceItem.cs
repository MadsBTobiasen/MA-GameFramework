using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.ItemObjects
{
    public class DefenceItem : IItemObject
    {

        #region Properties
        public int Id { get; set; }
        /// <summary>
        /// Name of the DefenceItem.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// DefenceRating of the DefenceItem.
        /// </summary>
        public int DefenceRating { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Create a new instance of DefenceItem.
        /// </summary>
        /// <param name="name">The name of the weapon.</param>
        /// <param name="defenceRating">How much damage the defenceItem will repel.</param>
        public DefenceItem(string name, int defenceRating)
        {
            Id = 0;
            Name = name;
            DefenceRating = defenceRating;
        }
        /// <summary>
        /// Create a new instance of DefenceItem.
        /// </summary>
        /// <param name="id">The id of the defenceItem.</param>
        /// <param name="name">The name of the defenceItem.</param>
        /// <param name="defenceRating">How much damage the defenceItem will repel.</param>
        public DefenceItem(int id, string name, int defenceRating)
        {
            Id = id;
            Name = name;
            DefenceRating = defenceRating;
        }

        /// <summary>
        /// Default constructor, to allow for reflection.
        /// </summary>
        public DefenceItem()
        {
            Name = "";
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"DefenceItem: ({Id}) {Name} {DefenceRating}";
        }
        #endregion

    }
}
