using System;
using System.Collections.Generic;
using PlateTD.Entities;
using PlateTD.Entities.DTO;
using PlateTD.Entities.Enums;
using PlateTD.SO;
using UnityEngine;

namespace PlateTD.Inventory
{
    public class InventoryService : MonoBehaviour
    {
        [SerializeField] private Transform _inventoryListTransform;
        [SerializeField] private InventoryPlatePanel _platePanelPrefab;

        private Dictionary<PlateType, PlateInventoryData> _inventory;
        private PlateType _selectedPlateType;

        public event Action<Vector2, PlateType> OnStartDragPanel;
        public event Action<Vector2, PlateType> OnEndDragPanel;

        public bool IsDragged { get; private set; }
        public Vector2 DragPosition { get; private set; }

        public void Init(List<PlateInventoryDTO> plateInventoryDatas)
        {
            IsDragged = false;
            _inventory = new Dictionary<PlateType, PlateInventoryData>();

            foreach (var plateData in plateInventoryDatas)
            {
                var platePanel = Instantiate(_platePanelPrefab, _inventoryListTransform);
                platePanel.SetPlatePanel(
                    0,
                    plateData.Sprite,
                    (point) => BeginDragHandler(point, plateData.Type),
                    (point) => EndDragHandler(point),
                    (point) => DragHandler(point));

                _inventory.Add(plateData.Type, new PlateInventoryData(platePanel));
            }
        }

        public void AddPlate(PlateType plateType)
        {
            var panel = _inventory[plateType];

            if (panel != null)
            {
                panel.Amount++;
                panel.InventoryPlatePanel.SetAmount(panel.Amount);
            }
        }

        public void ReducePlate(PlateType plateType)
        {
            var panel = _inventory[plateType];

            if (panel != null && panel.Amount > 0)
            {
                panel.Amount--;
                panel.InventoryPlatePanel.SetAmount(panel.Amount);
            }
        }

        private void BeginDragHandler(Vector2 beginDragPoint, PlateType plateType)
        {
            if (_inventory[plateType] != null && _inventory[plateType].Amount > 0)
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
    }
}