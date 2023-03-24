namespace MA_GameFramework.Objects.Entities
{
    /// <summary>
    /// Class that can hold coordinates for the game.
    /// </summary>
    public class Position
    {

        #region Properties
        /// <summary>
        /// Property indicating the x-coordinate of the position.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Property indicating the y-coordinate of the position.
        /// </summary>
        public int Y { get; set; }
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
        }
        /// <summary>
        /// Default Constructor to allow for reflection.
        /// </summary>
        public Position()
        { }
        #endregion

    }
}