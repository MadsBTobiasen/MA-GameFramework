using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.GameInputAdapters
{
    public abstract class GameInputAdapter<T> : 
        IGameInputAdapter<T, ConsoleKey>
    {

        #region Properties
        protected Dictionary<T, ConsoleKey> AdapterMap { get; set; }
        #endregion

        #region Constructor
        public GameInputAdapter()
        {
            AdapterMap = new Dictionary<T, ConsoleKey>();
        }
        #endregion

        #region Methods
        public virtual void AddMap(T input, ConsoleKey output)
        {

            if (AdapterMap.ContainsKey(input))
                TracerListeners.TS.TraceEvent(System.Diagnostics.TraceEventType.Warning, 999, $"KeyMap override in GameInputAdapter: {AdapterMap[input]} => {output}.");

            AdapterMap[input] = output;

        }

        public virtual ConsoleKey GetMap(T input)
        {
            return AdapterMap[input];
        }

        #endregion

    }
}
