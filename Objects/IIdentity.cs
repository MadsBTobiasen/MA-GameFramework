using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects
{
    public interface IIdentity<T>
    {

        /// <summary>
        /// Integer to add an Id to the object.
        /// </summary>
        T Id { get; set; }
        /// <summary>
        /// String to add a name to the object.
        /// </summary>
        string Name { get; }

    }
}
