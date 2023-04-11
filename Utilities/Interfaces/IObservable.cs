using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.Interfaces
{
    public interface IObservable<T>
    {

        /// <summary>
        /// List containing all of the Observers.
        /// </summary>
        public List<IObserver<T>> Observers { get; }

        /// <summary>
        /// Method that adds Observers to the Observable.
        /// </summary>
        /// <param name="observers">Collection of Observers</param>
        public void AddObservers(params IObserver<T>[] observers);

        /// <summary>
        /// Method that removes an Observer from the Observable.
        /// </summary>
        /// <param name="observer">Observer to remove.</param>
        public void RemoveObserver(IObserver<T> observer);

        /// <summary>
        /// Method that notifies the observers.
        /// </summary>
        public void NotifyObservers(T args);

    }
}
