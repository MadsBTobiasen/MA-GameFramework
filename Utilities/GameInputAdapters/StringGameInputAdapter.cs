using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities.GameInputAdapters
{
    /// <summary>
    /// Provide a GameInputAdapter for adapt strings.
    /// </summary>
    public class StringGameInputAdapter : GameInputAdapter<string>
    {

        #region Constructor
        public StringGameInputAdapter() : base()
        {
            foreach(ConsoleKey key in Enum.GetValues(typeof(ConsoleKey)))
            {
                AddMap(key.ToString().ToLower(), key);
            }
        }
        #endregion

        #region Methods
        public override void AddMap(string input, ConsoleKey output)
        {
            base.AddMap(input.ToLower(), output);
        }

        public override ConsoleKey GetMap(string input)
        {
            return base.GetMap(input.ToLower());
        }
        #endregion

    }
}
