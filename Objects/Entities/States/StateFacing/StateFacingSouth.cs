using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities.States.StateFacing
{
    public class StateFacingSouth : IState<Moves, bool>
    {

        #region Fields
        private Position _position;
        #endregion

        #region Constructor
        public StateFacingSouth(Position pos)
        {
            _position = pos;
            _position.MoveSouth();
        }
        #endregion

        #region Methods
        public IState<Moves, bool> NextState(Moves input)
        {

            if (input == Moves.Left)
            {
                return new StateFacingEast(_position);
            }

            if (input == Moves.Right)
            {
                return new StateFacingWest(_position);
            }

            if (input == Moves.Backward)
            {
                return new StateFacingNorth(_position);
            }

            return new StateFacingSouth(_position);

        }
        #endregion

    }
}
