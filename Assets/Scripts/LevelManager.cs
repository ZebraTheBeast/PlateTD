using System.Linq;
using PlateTD.Building;
using PlateTD.Inventory;
using PlateTD.Plates;
using PlateTD.Shop;
using PlateTD.SO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private PlateTypePlateDataConfig _plateConfig;
    [SerializeField] private InventoryService _inventoryService;
    [SerializeField] private BuildingService _buildingService;
    [SerializeField] private ShopService _shopService;

    [SerializeField] private ShopConfig _shopConfig;

    private void EndDragHandler(Vector2 screenPosition, PlateType plateType)
    {
        if (_buildingService.IsPlateExist(screenPosition))
        {
            if (_buildingService.IsPlateOfType(screenPosition, plateType))
            {
                // upgrade plate
            }
        }
        else
        {
            var platePrefab = _plateConfig.PlateTypePlateDatas.FirstOrDefault(item => item.Type == plateType).Data.Prefab;
            bool result = _buildingService.BuildPlate(screenPosition, plateType, platePrefab);
            
            if (result)
            {
                _inventoryService.ReducePlate(plateType);
            }
        }
    }

    private void PlateBuyHandler(PlateType plateType)
    {
        _inventoryService.AddPlate(plateType);
    }

    private void Start()
    {
        _inventoryService.Init(_plateConfig);
        _inventoryService.OnEndDragPanel += EndDragHandler;

        _shopService.Init(_shopConfig);
        _shopService.OnPlateBuy += PlateBuyHandler;
    }

    private void OnDestroy()
    {
        _inventoryService.OnEndDragPanel -= EndDragHandler;
        _shopService.OnPlateBuy -= PlateBuyHandler;
    }
}