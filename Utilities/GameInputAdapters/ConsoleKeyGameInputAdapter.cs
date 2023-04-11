using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.GameInputAdapters
{
    public class ConsoleKeyGameInputAdapter : GameInputAdapter<ConsoleKey>
    {

        #region Constructor
        public ConsoleKeyGameInputAdapter() : base()
        {
            foreach (ConsoleKey key in Enum.GetValues(typeof(ConsoleKey)))
            {
                AddMap(key, key);
            }
        }
        #endregion

        #region Methods
        public override void AddMap(ConsoleKey input, ConsoleKey output)
        {

            if (AdapterMap.ContainsKey(input))
                TracerListeners.TS.TraceEvent(System.Diagnostics.TraceEventType.Warning, 999, $"KeyMap override in GameInputAdapter: {AdapterMap[input]} => {output}.");

            AdapterMap[input] = output;

        }

        public override ConsoleKey GetMap(ConsoleKey input)
        {
            return AdapterMap[input];
        }
        #endregion

    }
}
