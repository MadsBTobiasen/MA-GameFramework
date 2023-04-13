using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities.States.StateFacing
{
    public class StateFacingEast : IState<Moves, bool>
    {

        #region Fields
        private Position _position;
        #endregion

        #region Constructor
        public StateFacingEast(Position pos)
        {
            _position = pos;
            _position.MoveEast();
        }
        #endregion

        #region Methods
        public IState<Moves, bool> NextState(Moves input)
        {

            Console.WriteLine("East");

            if (input == Moves.Left)
            {
                return new StateFacingNorth(_position);
            }

            if (input == Moves.Right)
            {
                return new StateFacingSouth(_position);
            }

            if (input == Moves.Backward)
            {
                return new StateFacingWest(_position);
            }

            return new StateFacingEast(_position);

        }
        #endregion

    }
}
