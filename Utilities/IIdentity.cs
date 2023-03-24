using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities
{
    public interface IIdentity<T>
    {

        /// <summary>
        /// Id of an object.
        /// </summary>
        T Id { get; set; }
        /// <summary>
        /// Name of an object.
        /// </summary>
        string Name { get; }

    }
}
