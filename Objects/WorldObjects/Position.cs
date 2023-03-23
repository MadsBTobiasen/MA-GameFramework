namespace MA_GameFramework.Objects.WorldObjects
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
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion

    }
}