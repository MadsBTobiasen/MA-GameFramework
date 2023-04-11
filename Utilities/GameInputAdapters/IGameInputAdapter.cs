namespace MA_GameFramework.Utilities.GameInputAdapters
{
    public interface IGameInputAdapter<TIn, TOut>
    {        
        /// <summary>
        /// Method that adds a mapping to the Adapter.
        /// </summary>
        /// <param name="input">Input to be converted.</param>
        /// <param name="output">Output that input got converted to.</param>
        void AddMap(TIn input, TOut output);

        /// <summary>
        /// Method that gets the map for the specified input.
        /// </summary>
        /// <param name="input">Input to adapt.</param>
        /// <returns>Nullable ConsoleKey. Null if it dosen't exist.</returns>
        TOut? GetMap(TIn input);

    }
}