using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Controllers
{
    /// <summary>
    /// InputController that defines 
    /// </summary>
    /// <typeparam name="TInput">Input type that the controller handles.</typeparam>
    public interface IInputController<TInput>
    {

        /// <summary>
        /// Property holding all the ConsoleKeys that the InputController can handle.
        /// </summary>
        public List<TInput> AcceptedInput { get; }

        /// <summary>
        /// Method that adds a Key to the Controller.
        /// </summary>
        public void AddKey(TInput key);
        /// <summary>
        /// Method that adds Keys to the Controller.
        /// </summary>
        public void AddKeys(params TInput[] key);

        /// <summary>
        /// Function that handles Input.
        /// </summary>
        /// <param name="key">ConsoleKey that was entered.</param>
        /// <returns>Bool to indicate if the Input was used / accepted.</returns>
        public bool HandleInput(TInput key);


    }

}
