using UnityEngine;
using PlateTD.Utilities.Grid;
using PlateTD.SO;
using PlateTD.Entities;
using PlateTD.Plates;
using PlateTD.Utilities;

namespace PlateTD.Building
{
    public class BuildingService : MonoBehaviour
    {
        [SerializeField] private Transform _fieldTransform;
        [SerializeField] private LayerMask _fieldLayerMask;

        [SerializeField] private int _columnCount;
        [SerializeField] private int _rowCount;
        [SerializeField] private float _cellSize;

        [SerializeField] private BuildingController _plateBuidlingController;

        private GridSystem<PlacedPlateData> _gridSystem;

        public bool IsPlateExist(Vector2 screenPosition)
        {
            if (Mouse3D.TryGetPosition(screenPosition, _fieldLayerMask, out Vector3 position))
            {
                _gridSystem.GetXY(position, out int x, out int y);
                PlacedPlateData placedPlateData = _gridSystem.GetValue(x, y);

                return placedPlateData != null;
            }

            return false;
        }

        public bool TryUpgradePlate(Vector2 screenPosition, PlateType plateType)
        {
            if (Mouse3D.TryGetPosition(screenPosition, _fieldLayerMask, out Vector3 position))
            {
                _gridSystem.GetXY(position, out int x, out int y);
                PlacedPlateData placedPlateData = _gridSystem.GetValue(x, y);

                if (placedPlateData != null && 
                    placedPlateData.Type == plateType)
                {
                    return placedPlateData.PlateBehaviour.TryUpgradePlate();
                }
            }

            return false;
        }

        public bool BuildPlate(Vector2 screenPosition, PlateType plateType, PlateBehaviour platePrefab)
        {
            if (Mouse3D.TryGetPosition(screenPosition, _fieldLayerMask, out Vector3 position))
            {
                _gridSystem.GetXY(position, out int x, out int y);
                PlacedPlateData placedPlateData = _gridSystem.GetValue(x, y);

                if (placedPlateData == null)
                {
                    var plateBehaviour = Instantiate(platePrefab, _gridSystem.GetCenteredWorldPosition(x, y), Quaternion.identity);
                    plateBehaviour.UpdatePlateRenderer();
                    var value = new PlacedPlateData(plateType, plateBehaviour);
                    _gridSystem.SetValue(x, y, value);
                    return true;
                }
            }

            return false;
        }

        private void FieldClickHandler(Vector3 clickPoint)
        {
            _gridSystem.GetXY(clickPoint, out int x, out int y);
            var position = _gridSystem.GetCenteredWorldPosition(x, y);
            if (!_gridSystem.IsOccupied(x, y))
            {
                Debug.Log($"{x} - {y}");
                // Instantiate(_plateData.Prefab, position, Quaternion.identity);
                // _gridSystem.SetValue(x, y, 1);
            }
        }

        private void Awake()
        {
            _gridSystem = new GridSystem<PlacedPlateData>(_columnCount, _rowCount, _cellSize, _fieldTransform.position);
        }

        private void Start()
        {
            _plateBuidlingController.SetFieldLayerMask(_fieldLayerMask);
            _plateBuidlingController.OnFieldClick += FieldClickHandler;


        }

        private void Update()
        {

        }

        private void OnDestroy()
        {
            _plateBuidlingController.OnFieldClick -= FieldClickHandler;
        }
    }
}
