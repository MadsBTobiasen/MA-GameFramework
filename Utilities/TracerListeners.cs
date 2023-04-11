using MA_GameFramework.Utilities.XMLBuilders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities
{
    /// <summary>
    /// Class containing all TracerListeners.
    /// </summary>
    public static class TracerListeners
    {

        #region Fields
        private const string _name = "MA-Gameframework";
        private const string _fileName = $"{_name}.log";
        #endregion

        #region Tracers
        public static TraceSource TS { get; set; } = CreateSource();
        #endregion

        #region Methods
        private static TraceSource CreateSource()
        {
            TraceSource ts = new TraceSource(_name);
            ts.Switch = new SourceSwitch($"{_name}-log", "All");

            ts.Listeners.Add(CreateListener(SourceLevels.Information));

            ts.TraceEvent(TraceEventType.Information, 999, "Tracer Initialized.");

            Trace.AutoFlush = true;

            return ts;
        }

        private static TraceListener CreateListener(SourceLevels sl)
        {

            TraceListener tl = new TextWriterTraceListener(new StreamWriter(_fileName) { AutoFlush = true });
            tl.Filter = new EventTypeFilter(sl);

            return tl;

        }
        #endregion

    }
}
