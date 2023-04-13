using MA_GameFramework.Objects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA_GameFramework.Utilities
{
    public class WorldMatrix
    {

        #region Fields
        private IEntity?[,] _initialGrid => new IEntity?[_initialRows, _initialColumns];
        private IEntity?[,] _grid;

        private int _initialRows;
        private int _initialColumns;
        #endregion

        #region Constructor
        public WorldMatrix(int sizeX, int sizeY)
        {
            _initialRows = sizeY;
            _initialColumns = sizeX;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Method that resets the Matrix.
        /// </summary>
        public void Reset()
        {
            _grid = _initialGrid;
        }
        /// <summary>
        /// Method that adds an Entity to the matrix.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        public void SetPosition(IEntity entity)
        {
            _grid[entity.Position.Y, entity.Position.X] = entity;
        }

        /// <summary>
        /// Method that returns the Matrix.
        /// </summary>
        /// <returns>2d Array of Nullable IEntity.</returns>
        public IEntity?[,] GetMatrix()
        {
            return _grid;
        }
        #endregion 

    }
}
