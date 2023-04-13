using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities.States.StateFacing
{
    public class StateFacingWest : IState<Moves, bool>
    {

        #region Fields
        private Position _position;
        #endregion

        #region Constructor
        public StateFacingWest(Position pos)
        {
            _position = pos;
            _position.MoveWest();
        }
        #endregion

        #region Methods
        public IState<Moves, bool> NextState(Moves input)
        {

            if (input == Moves.Left)
            {
                return new StateFacingSouth(_position);
            }

            if (input == Moves.Right)
            {
                return new StateFacingNorth(_position);
            }

            if (input == Moves.Backward)
            {
                return new StateFacingEast(_position);
            }
            
            return new StateFacingWest(_position);

        }
        #endregion

    }
}
