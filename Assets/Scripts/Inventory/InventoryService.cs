using System;
using System.Collections.Generic;
using PlateTD.Entities;
using PlateTD.Plates;
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

        public event Action<Vector2, PlateType> OnEndDragPanel;

        public void Init(PlateTypePlateDataConfig intentoryPlateData)
        {
            _inventory = new Dictionary<PlateType, PlateInventoryData>();

            foreach (var plateData in intentoryPlateData.PlateTypePlateDatas)
            {
                var platePanel = Instantiate(_platePanelPrefab, _inventoryListTransform);
                platePanel.SetPlatePanel(
                    0,
                    plateData.Data.Sprite,
                    delegate { BeginDragHandler(plateData.Type); },
                    (point) => EndDragHandler(point));

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

        private void BeginDragHandler(PlateType plateType)
        {
            if (_inventory[plateType] != null && _inventory[plateType].Amount > 0)
            {
                Debug.Log($"[{this.GetType().Name}][BeginDragHandler] Begin drag {plateType}");
                _selectedPlateType = plateType;
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
        }
    }
}