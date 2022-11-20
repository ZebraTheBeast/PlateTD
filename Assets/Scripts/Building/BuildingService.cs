using UnityEngine;
using PlateTD.Utilities.Grid;
using PlateTD.Entities;
using PlateTD.Utilities;
using PlateTD.Entities.Enums;
using PlateTD.Repositories.Interfaces;
using PlateTD.Extensions;

namespace PlateTD.Building
{
    public class BuildingService : MonoBehaviour
    {
        [SerializeField] private Transform _fieldTransform;
        [SerializeField] private LayerMask _fieldLayerMask;

        [SerializeField] private Material _ghostMaterialSuccess;
        [SerializeField] private Material _ghostMaterialFail;

        [SerializeField] private int _columnCount;
        [SerializeField] private int _rowCount;
        [SerializeField] private float _cellSize;

        [SerializeField] private float _ghostOffsetCamera = 5f;
        [SerializeField] private Vector3 _ghostOffsetPlate = new Vector3(0, 0, -0.5f);

        [SerializeField] private BuildingController _plateBuidlingController;
        private BuildingGhostController _buildingGhostController;

        private GridSystem<PlacedPlateData> _gridSystem;

        private IPlateRepository _plateRepository;

        private PlateType _ghostPlateType;

        [SerializeField] private SellPlateView _sellPlateView;

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

        public bool BuildPlate(Vector2 screenPosition, PlateType plateType)
        {
            if (Mouse3D.TryGetPosition(screenPosition, _fieldLayerMask, out Vector3 position))
            {
                _gridSystem.GetXY(position, out int x, out int y);
                PlacedPlateData placedPlateData = _gridSystem.GetValue(x, y);

                if (placedPlateData == null)
                {
                    var plateBuildingData = _plateRepository.GetPlateBuildingDTOByPlateType(plateType);
                    var plateBehaviour = Instantiate(plateBuildingData.Prefab, _gridSystem.GetCenteredWorldPosition(x, y), Quaternion.identity);
                    plateBehaviour.SetPlateData(plateBuildingData.PlateData);
                    plateBehaviour.UpdatePlate();
                    var value = new PlacedPlateData(plateType, plateBehaviour);
                    _gridSystem.SetValue(x, y, value);
                    return true;
                }
            }

            return false;
        }

        public void CreateGhost(PlateType plateType, Vector2 screenPosition)
        {
            var plateAppearance = _plateRepository.GetPlateAppearanceByPlateType(plateType);
            _ghostPlateType = plateType;

            _buildingGhostController.CreateGhost(plateAppearance, screenPosition);
        }

        public void UpdateGhost(Vector2 screenPosition)
        {
            if (_buildingGhostController.IsActive)
            {
                Vector3 ghostPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, _ghostOffsetCamera));
                var ghostCanBePlased = false;

                if (Mouse3D.TryGetPosition(screenPosition, _fieldLayerMask, out Vector3 position))
                {
                    _gridSystem.GetXY(position, out int x, out int y);
                    PlacedPlateData placedPlateData = _gridSystem.GetValue(x, y);
                    ghostPosition = _gridSystem.GetCenteredWorldPosition(x, y) + _ghostOffsetPlate;

                    if (placedPlateData == null ||
                        (placedPlateData.Type == _ghostPlateType &&
                        placedPlateData.PlateBehaviour.IsUpgradable()))
                    {
                        ghostCanBePlased = true;
                    }
                }

                _buildingGhostController.Update(ghostPosition, ghostCanBePlased);
            }
        }

        public void DestroyGhost()
        {
            _buildingGhostController.DestroyGhost();
        }

        private void FieldClickHandler(Vector3 clickPoint)
        {
            _gridSystem.GetXY(clickPoint, out int x, out int y);
            var position = _gridSystem.GetCenteredWorldPosition(x, y);
            if (_gridSystem.IsOccupied(x, y))
            {
                position = Camera.main.WorldToScreenPoint(position);
                _sellPlateView.ShowAt(position);
                _sellPlateView.SetSellButtonCallback(() => SellPlate(x, y));
            }
            else
            {
                _sellPlateView.Hide();
            }
        }

        private void SellPlate(int x, int y)
        {
            var placedPlateData = _gridSystem.GetValue(x, y);
            placedPlateData.PlateBehaviour.SellPlate();
            _gridSystem.ResetValue(x, y);
            _sellPlateView.Hide();
        }

        private void FieldMissClickHandler()
        {
            _sellPlateView.Hide();
        }

        private void Awake()
        {
            _gridSystem = new GridSystem<PlacedPlateData>(_columnCount, _rowCount, _cellSize, _fieldTransform.position);
            _buildingGhostController = new BuildingGhostController(_ghostMaterialSuccess, _ghostMaterialFail);
        }

        private void Start()
        {
            _plateBuidlingController.SetFieldLayerMask(_fieldLayerMask);
            _plateBuidlingController.OnFieldClick += FieldClickHandler;
            _plateBuidlingController.OnFieldMissClick += FieldMissClickHandler;

            _plateRepository = ServiceLocator.Resolve<IPlateRepository>();
        }

        private void OnDestroy()
        {
            _plateBuidlingController.OnFieldClick -= FieldClickHandler;
            _plateBuidlingController.OnFieldMissClick -= FieldMissClickHandler;
        }
    }
}
