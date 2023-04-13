using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Objects.Entities.States.StateFacing
{
    
    public enum Moves
    {
        Forward,
        Backward,
        Right,
        Left
    }

    public class StateFacingInitial : IState<Moves, bool>
    {

        #region Fields
        private Position _position;
        #endregion

        #region Constructor
        public StateFacingInitial(Position pos)
        {
            _position = pos;
        }
        #endregion

        #region Methods
        public IState<Moves, bool> NextState(Moves input)
        {

            if (input == Moves.Left)
            {
                return new StateFacingWest(_position);
            }

            if (input == Moves.Right)
            {
                return new StateFacingEast(_position);
            }

            if (input == Moves.Backward)
            {
                return new StateFacingSouth(_position);
            }

            return new StateFacingNorth(_position);

        }
        #endregion

    }
}
