using System.Linq;
using PlateTD.Building;
using PlateTD.EnemyRepository;
using PlateTD.EnemyRepository.Interfaces;
using PlateTD.Entities.Enums;
using PlateTD.Extensions;
using PlateTD.Inventory;
using PlateTD.Shop;
using PlateTD.SO;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private WaveService _waveService;
    [SerializeField] private DragAndDropInventoryService _dragAndDropInventoryService;
    [SerializeField] private BuildingService _buildingService;

    private ShopService _shopService;
    private InventoryService _inventoryService;

    [SerializeField] private ShopConfig _shopConfig;
    [SerializeField] private InventoryConfig _inventoryConfig;
    [SerializeField] private WaveConfig _waveConfig;
    [SerializeField] private PlateDataConfig _plateDataConfig;
    [SerializeField] private EnemyConfig _enemyConfig;

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

    private void AddGoldHandler(int goldAmount)
    {
        _shopService.AddGold(goldAmount);
    }

    private void PrepareShopService()
    {
        _shopService = new ShopService(_shopConfig);
        ServiceLocator.RegisterService<ShopService>(_shopService);
    }

    private void PrepareInventoryService()
    {
        _inventoryService = new InventoryService(_inventoryConfig);
        ServiceLocator.RegisterService<InventoryService>(_inventoryService);
    }

    private void PrepareWaveService()
    {
        IEnemyRepository enemyRepository = new EnemyRepository(_enemyConfig.EnemySOList);
        _waveService.Init(_waveConfig, enemyRepository);
    }

    private PlateSO GetPlateSoByType(PlateType type)
    {
        return _plateDataConfig.PlateSOList.FirstOrDefault(item => item.PlateType == type);
    }

    private void StartWaveHandler()
    {
        _waveService.TrySetNextWave();
        _waveService.StartWave();
    }

    private void Awake()
    {
        PrepareShopService();
        PrepareInventoryService();
        PrepareWaveService();
    }

    private void Start()
    {
        _dragAndDropInventoryService.Init(_plateDataConfig.ToPlateInventoryViewDTO(_inventoryConfig));
        _dragAndDropInventoryService.OnEndDragPanel += EndDragHandler;
        _dragAndDropInventoryService.OnStartDragPanel += StartDragHandler;

        _shopService.OnPlateBuy += PlateBuyHandler;

        GameEvents.OnAddGold += AddGoldHandler;
        GameEvents.OnStartWave += StartWaveHandler;
    }

    private void Update()
    {
        if (_dragAndDropInventoryService.IsDragged)
        {
            _buildingService.UpdateGhost(_dragAndDropInventoryService.DragPosition);
        }
    }

    private void OnDestroy()
    {
        _dragAndDropInventoryService.OnEndDragPanel -= EndDragHandler;
        _dragAndDropInventoryService.OnStartDragPanel -= StartDragHandler;

        _shopService.OnPlateBuy -= PlateBuyHandler;

        ServiceLocator.RemoveService<ShopService>();
        ServiceLocator.RemoveService<InventoryService>();

        GameEvents.OnAddGold -= AddGoldHandler;
        GameEvents.OnStartWave -= StartWaveHandler;
    }
}