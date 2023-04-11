using MA_GameFramework.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Items
{
    public abstract class Item : IItem, IValidate
    {

        #region Properties
        public int Id { get; set; } = -1;
        public string Name { get; set; }
        #endregion

        #region Constructor
        public Item()
        {
            Name = "";
        }
        #endregion

        #region Methods
        public virtual void Validate()
        {

            if (Id < 0)
                throw new ArgumentException("Id cannot be less than 0.");

            if (string.IsNullOrEmpty(Name) || Name.Length < 2)
                throw new ArgumentException("Name cannot be null, or less than 2 characters.");

        }
        #endregion

    }
}
