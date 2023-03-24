using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Items
{
    public abstract class Item : IItem
    {

        #region Properties
        public int Id { get; set; } = -1;
        public string Name { get; set; }
        #endregion

        #region Methods
        public Item()
        {
            Name = "";
        }
        #endregion

    }
}
