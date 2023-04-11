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
    public class IntegerGameInputAdapter : GameInputAdapter<int>
    {

        #region Constructor
        public IntegerGameInputAdapter() : base()
        {
            foreach (ConsoleKey key in Enum.GetValues(typeof(ConsoleKey)))
            {
                AddMap((int)key, key);
            }
        }
        #endregion

        #region Methods
        public override void AddMap(int input, ConsoleKey output)
        {
            base.AddMap(input, output);
        }

        public override ConsoleKey GetMap(int input)
        {
            return base.GetMap(input);
        }
        #endregion

    }
}
