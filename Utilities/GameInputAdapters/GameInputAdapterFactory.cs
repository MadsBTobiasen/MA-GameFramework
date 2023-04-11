using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.GameInputAdapters
{
    public static class GameInputAdapterFactory
    {

        /// <summary>
        /// Factory-Method that gets a predefined GameInputAdapter.
        /// </summary>
        /// <typeparam name="T">Type to find.</typeparam>
        /// <returns>Instance of IGameInputAdapter</returns>
        public static IGameInputAdapter<T1, T2> CreateGameInputAdapter<T1, T2>()
        {

            Console.WriteLine($"type: {typeof(T1).Name}");

            if (typeof(T1).Name == "string")
                return (IGameInputAdapter<T1, T2>) new StringGameInputAdapter();
            
            if (typeof(T1).Name == "int")
                return (IGameInputAdapter<T1, T2>) new IntegerGameInputAdapter();

            if (typeof(T1).Name == "ConsoleKey")
                return (IGameInputAdapter<T1, T2>) new ConsoleKeyGameInputAdapter();

            throw new InvalidOperationException($"No GameInputAdapter found with type: {typeof(T1).Name}");

        }

    }
}
