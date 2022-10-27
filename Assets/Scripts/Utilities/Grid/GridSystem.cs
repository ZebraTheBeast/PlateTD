using System;
using UnityEngine;

namespace PlateTD.Utilities.Grid
{
    public class GridSystem<T>
    {
        private int _columnCount;
        private int _rowCount;
        private float _cellSize;
        private GridCell<T>[,] _grid;

        private Vector3 _startPosition;

        public GridSystem(int columnCount, int rowCount, float cellSize, Vector3 startPosition)
        {
            if (columnCount <= 0) throw new Exception($"{this.GetType().Name}[GridSystem] columnCount <= 0");
            if (rowCount <= 0) throw new Exception($"{this.GetType().Name}[GridSystem] rowCount <= 0");
            if (cellSize <= 0) throw new Exception($"{this.GetType().Name}[GridSystem] cellSize <= 0");

            _columnCount = columnCount;
            _rowCount = rowCount;
            _cellSize = cellSize;
            _startPosition = startPosition;

            _grid = new GridCell<T>[_columnCount, _rowCount];
            for (int i = 0; i < _columnCount; i++)
            {
                for (int j = 0; j < _rowCount; j++)
                {
                    _grid[i, j] = new GridCell<T>(i, j);
                }
            }
        }

        public Vector3 GetWorldPosition(int x, int y)
        {
            return _startPosition + (new Vector3(x, y) * _cellSize);
        }

        public Vector3 GetCenteredWorldPosition(int x, int y)
        {
            return GetWorldPosition(x, y) + new Vector3(_cellSize, _cellSize) * 0.5f;
        }

        public void GetXY(Vector3 position, out int x, out int y)
        {
            x = (int)(position.x / _cellSize);
            y = (int)(position.y / _cellSize);
        }

        public void SetValue(int x, int y, T value)
        {
            _grid[x, y].Occupied = true;
            _grid[x, y].Value = value;
        }

        public void ResetValue(int x, int y)
        {
            _grid[x, y].Occupied = false;
            _grid[x, y].Value = default(T);
        }

        public bool IsOccupied(int x, int y)
        {
            return _grid[x, y].Occupied;
        }

        public T GetValue(int x, int y)
        {
            return _grid[x, y].Value;
        }
    }
}
