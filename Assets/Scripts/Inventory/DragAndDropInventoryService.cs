using System;
using System.Collections.Generic;
using PlateTD.Entities.Enums;
using PlateTD.Extensions;
using PlateTD.Repositories.Interfaces;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Inventory
{
    public class DragAndDropInventoryService : MonoBehaviour
    {
        [SerializeField] private Transform _inventoryListTransform;
        [SerializeField] private InventoryPlatePanel _platePanelPrefab;

        private Dictionary<PlateType, InventoryPlatePanel> _platePanels;

        private PlateType _selectedPlateType;

        private InventoryService _inventoryService;
        private IPlateRepository _plateRepository;

        public event Action<Vector2, PlateType> OnStartDragPanel;
        public event Action<Vector2, PlateType> OnEndDragPanel;

        public bool IsDragged { get; private set; }
        public Vector2 DragPosition { get; private set; }

        public void Init(InventoryConfig inventoryConfig)
        {
            ResolvePlateRepository();
            IsDragged = false;
            _platePanels = new Dictionary<PlateType, InventoryPlatePanel>();

            foreach (var plateData in inventoryConfig.StartPlates)
            {
                var sprite = _plateRepository.GetPlateSpriteByType(plateData.Type);

                var platePanel = Instantiate(_platePanelPrefab, _inventoryListTransform);
                platePanel.SetPlatePanel(
                    plateData.Amount,
                    sprite,
                    (point) => BeginDragHandler(point, plateData.Type),
                    (point) => EndDragHandler(point),
                    (point) => DragHandler(point));
                _platePanels.Add(plateData.Type, platePanel);
            }
        }

        private void BeginDragHandler(Vector2 beginDragPoint, PlateType plateType)
        {
            if (_inventoryService.GetPlateAmount(plateType) > 0)
            {
                _selectedPlateType = plateType;
                OnStartDragPanel?.Invoke(beginDragPoint, plateType);
                IsDragged = true;
            }
            else
            {
                _selectedPlateType = PlateType.None;
            }
        }

        private void EndDragHandler(Vector2 endDragPoint)
        {
            if (_selectedPlateType != PlateType.None)
            {
                OnEndDragPanel?.Invoke(endDragPoint, _selectedPlateType);
            }

            _selectedPlateType = PlateType.None;
            IsDragged = false;
        }

        private void DragHandler(Vector2 position)
        {
            DragPosition = position;
        }

        private void PlateTypeAmountChanged(PlateType plateType, int amount)
        {
            if (_platePanels.ContainsKey(plateType))
            {
                _platePanels[plateType].SetAmount(amount);
            }
        }

        private void ResolvePlateRepository()
        {
            if (_plateRepository == null)
            {
                _plateRepository = ServiceLocator.Resolve<IPlateRepository>();
            }
        }

        private void Start()
        {
            _inventoryService = ServiceLocator.Resolve<InventoryService>();
            _inventoryService.OnPlateTypeAmountChanged += PlateTypeAmountChanged;
        }

        private void OnDestroy()
        {
            _inventoryService.OnPlateTypeAmountChanged -= PlateTypeAmountChanged;
        }
    }
}