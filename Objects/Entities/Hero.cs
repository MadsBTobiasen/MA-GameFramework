using MA_GameFramework.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities
{
    public class Hero : Creature, IControllable
    {


        #region Properties
        public ConsoleKey MoveForward { get; private set; }

        public ConsoleKey MoveBackward { get; private set; }

        public ConsoleKey TurnRight { get; private set; }

        public ConsoleKey TurnLeft { get; private set; }
        public List<ConsoleKey> Keys => new List<ConsoleKey>() { MoveForward, MoveBackward, TurnRight, TurnLeft };
        #endregion
        public Hero(ConsoleKey moveForward, ConsoleKey moveBackward, ConsoleKey turnRight, ConsoleKey turnLeft)
        {
            MoveForward = moveForward;
            MoveBackward = moveBackward;
            TurnRight = turnRight;
            TurnLeft = turnLeft;
        }

        #region Methods
        public void Notify(object? sender, GenericEventArgs<ConsoleKey> args)
        {
            
            if (sender == null)
                return;

            Console.WriteLine(this);

        }
        #endregion

    }
}
