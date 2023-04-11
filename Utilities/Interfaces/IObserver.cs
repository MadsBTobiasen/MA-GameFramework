using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.Interfaces
{
    /// <summary>
    /// Observer Interface, for declaring observer-types.
    /// </summary>
    /// <typeparam name="T">Argument used in the EventArgs</typeparam>
    public interface IObserver<T> where T : notnull
    {

        /// <summary>
        /// Observer Function that notifies the object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        void Notify(object? sender, GenericEventArgs<T> args);

    }
}
