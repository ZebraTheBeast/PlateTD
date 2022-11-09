using System.Linq;
using PlateTD.Building;
using PlateTD.Entities.Enums;
using PlateTD.Extensions;
using PlateTD.Inventory;
using PlateTD.Shop;
using PlateTD.SO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlateDataConfig _plateDataConfig;
    [SerializeField] private InventoryService _inventoryService;
    [SerializeField] private BuildingService _buildingService;
    [SerializeField] private ShopService _shopService;

    [SerializeField] private ShopConfig _shopConfig;

    private void StartDragHandler(Vector2 screenPosition, PlateType plateType)
    {
        var plateRenderer = GetPlateSoByType(plateType).PlateRenderer;

        _buildingService.CreateGhost(plateRenderer, screenPosition);
    }

    private void EndDragHandler(Vector2 screenPosition, PlateType plateType)
    {
        if (_buildingService.IsPlateExist(screenPosition))
        {
            if (_buildingService.TryUpgradePlate(screenPosition, plateType))
            {
                _inventoryService.ReducePlate(plateType);
            }
        }
        else
        {
            var plateSO = GetPlateSoByType(plateType);
            bool result = _buildingService.BuildPlate(screenPosition, plateType, plateSO.ToPlateBuildingDTO());

            if (result)
            {
                _inventoryService.ReducePlate(plateType);
            }
        }
        _buildingService.DestroyGhost();
    }

    private void PlateBuyHandler(PlateType plateType)
    {
        _inventoryService.AddPlate(plateType);
    }

    private void Start()
    {
        _inventoryService.Init(_plateDataConfig.ToPlateInventoryDTO());
        _inventoryService.OnEndDragPanel += EndDragHandler;
        _inventoryService.OnStartDragPanel += StartDragHandler;

        _shopService.Init(_shopConfig);
        _shopService.OnPlateBuy += PlateBuyHandler;
    }

    private void Update()
    {
        if(_inventoryService.IsDragged)
        {
            _buildingService.UpdateGhost(_inventoryService.DragPosition);
        }
    }

    private void OnDestroy()
    {
        _inventoryService.OnEndDragPanel -= EndDragHandler;
        _inventoryService.OnStartDragPanel -= StartDragHandler;
        _shopService.OnPlateBuy -= PlateBuyHandler;
    }

    private PlateSO GetPlateSoByType(PlateType type)
    {
        return _plateDataConfig.PlateSOList.FirstOrDefault(item => item.PlateType == type);
    }
}