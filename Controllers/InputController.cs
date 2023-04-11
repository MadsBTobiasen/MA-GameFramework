using MA_GameFramework.Utilities.GameInputAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Controllers
{
    public class InputController<TInput> :
        BaseInputController<TInput, ConsoleKey>
        where TInput : struct
    {


        #region Constructor
        public InputController() : base() 
        { }

        public InputController(IGameInputAdapter<TInput, ConsoleKey> gameInputAdapter) : base(gameInputAdapter)
        { }
        #endregion

    }
}
