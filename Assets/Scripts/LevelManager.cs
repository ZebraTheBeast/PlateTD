using UnityEngine;
using PlateTD.Utilities.Grid;
using PlateTD.Utilities;

namespace PlateTD
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject _platePrefab;
        [SerializeField] private Transform _startPosition;

        [SerializeField] private int _columnCount;
        [SerializeField] private int _rowCount;
        [SerializeField] private float _cellSize;

        private GridSystem<int> _gridSystem;

        private void Awake()
        {
            _gridSystem = new GridSystem<int>(_columnCount, _rowCount, _cellSize, _startPosition.position);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _gridSystem.GetXY(Mouse3D.GetPosition(), out int x, out int y);
                var position = _gridSystem.GetCenteredWorldPosition(x, y);
                if (!_gridSystem.IsOccupied(x, y))
                {
                    Instantiate(_platePrefab, position, Quaternion.identity);
                    _gridSystem.SetValue(x, y, 1);
                }
            }
        }
    }
}
