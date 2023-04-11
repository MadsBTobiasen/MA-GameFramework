using MA_GameFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Controllers
{
    public abstract class ObserverInputController :
        BaseInputController<ConsoleKey>,
        Utilities.Interfaces.IObserver<ConsoleKey>
    {

        #region Constructor
        public ObserverInputController() : base()
        { }
        #endregion

        #region Methods
        public void Notify(object? sender, GenericEventArgs<ConsoleKey> args)
        {

            if (sender == null)
                return;

            HandleInput(args.Value);

        }
        #endregion

    }
}
