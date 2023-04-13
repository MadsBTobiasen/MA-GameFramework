using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities.States
{
    public interface IState<Tin, Tout>
    {

        /// <summary>
        /// Method that handles the change for a state.
        /// </summary>
        public IState<Tin, Tout> NextState(Tin input);

    }
}
