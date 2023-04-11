using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities
{
    public class GenericEventArgs<T> : EventArgs
    {

        #region Properties
        /// <summary>
        /// Arguments passed to the event.
        /// </summary>
        public T Value { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the EventArgs.
        /// </summary>
        /// <param name="value">Value to pass.</param>
        public GenericEventArgs(T value) : base()
        {
            Value = value;  
        }
        #endregion

    }
}
