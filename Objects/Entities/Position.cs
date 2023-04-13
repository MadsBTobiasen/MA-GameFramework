using System.Data.Common;

namespace MA_GameFramework.Objects.Entities
{
    /// <summary>
    /// Class that can hold coordinates for the game.
    /// </summary>
    public class Position
    {

        #region Fields
        private int _maxX;
        private int _maxY;
        private char _direction;
        #endregion

        #region Properties
        /// <summary>
        /// Property indicating the x-coordinate of the position.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Property indicating the y-coordinate of the position.
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Character indicating Direction.
        /// </summary>
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for the Position.
        /// </summary>
        /// <param name="x">Sets the start-x.</param>
        /// <param name="y">Sets the start-y.</param>
        public Position(int x, int y)
        {
            X = x;
            Y = y;
            _direction = '↑';
        }
        /// <summary>
        /// Constructor for the Position.
        /// </summary>
        /// <param name="x">Sets the start-x.</param>
        /// <param name="y">Sets the start-y.</param>
        public Position(int x, int y, int maxX, int maxY)
        {
            X = x;
            Y = y;
            _maxX = maxX;
            _maxY = maxY;
            _direction = '↑';
        }
        /// <summary>
        /// Default Constructor to allow for reflection.
        /// </summary>
        public Position()
        {
            _direction = '↑';
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get a Randomized Position Object.
        /// </summary>
        /// <returns></returns>
        public static Position GetRandom(int maxX, int maxY)
        {
            Random rnd = new Random();
            return new Position(rnd.Next(maxX), rnd.Next(maxY), maxX, maxY);
        }
        /// <summary>
        /// Method that sets the boundary for the position.
        /// </summary>
        /// <param name="maxX">Max X.</param>
        /// <param name="maxY">Max Y.</param>
        public void SetBoundary(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
        }

        /// <summary>
        /// Method that returns the Direction char.
        /// </summary>
        /// <returns>Char</returns>
        public char GetDirection()
        {
            return _direction;
        }

        /// <summary>
        /// Method that moves the position north.
        /// </summary>
        public void MoveNorth()
        {
            if (Y - 1 >= 0)
                Y--;
            _direction = '↑';

        }
        
        /// <summary>
        /// Method that moves the position north.
        /// </summary>
        public void MoveEast()
        {
            if (X + 1 < _maxX)
                X++;
            _direction = '→';
        }

        /// <summary>
        /// Method that moves the position north.
        /// </summary>
        public void MoveSouth()
        {
            if (Y + 1 < _maxY)
                Y++;
            _direction = '↓';
        }

        /// <summary>
        /// Method that moves the position north.
        /// </summary>
        public void MoveWest()
        {
            if (X - 1 >= 0)
                X--;
            _direction = '←';
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
        #endregion

    }
}