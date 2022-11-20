using PlateTD.Building;
using PlateTD.Repositories;
using PlateTD.Repositories.Interfaces;
using PlateTD.Entities.Enums;
using PlateTD.Extensions;
using PlateTD.Inventory;
using PlateTD.Shop;
using PlateTD.SO;
using UnityEngine;
using PlateTD.LevelHealth;
using PlateTD.Waves;
using PlateTD.EndLevelService;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private WaveService _waveService;
    [SerializeField] private DragAndDropInventoryService _dragAndDropInventoryService;
    [SerializeField] private BuildingService _buildingService;

    private ShopService _shopService;
    private InventoryService _inventoryService;
    private LevelHealthService _levelHealthService;
    private EndLevelService _endLevelService;

    [SerializeField] private int _levelHeatlh = 3;
    [SerializeField] private ShopConfig _shopConfig;
    [SerializeField] private InventoryConfig _inventoryConfig;
    [SerializeField] private WaveConfig _waveConfig;
    [SerializeField] private PlateDataConfig _plateDataConfig;
    [SerializeField] private EnemyConfig _enemyConfig;

    [SerializeField] private EndLevelView _endLevelView;

    private void StartDragHandler(Vector2 screenPosition, PlateType plateType)
    {
        _buildingService.CreateGhost(plateType, screenPosition);
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
            bool result = _buildingService.BuildPlate(screenPosition, plateType);

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

    private void PrepareEnemyRepository()
    {
        IEnemyRepository enemyRepository = new EnemyRepository(_enemyConfig.EnemySOList);
        ServiceLocator.RegisterService<IEnemyRepository>(enemyRepository);
    }

    private void StartWaveHandler()
    {
        if (_waveService.TrySetNextWave())
        {
            _waveService.StartWave();
        }
    }

    private void EndWaveHandler(bool isLastWave)
    {
        if (isLastWave && _levelHealthService.IsAlive)
        {
            _endLevelService.ShowWinView();
        }
    }

    private void HealthEndHandler()
    {
        _endLevelService.ShowLostView();
    }

    private void PreparePlateRepository()
    {
        var plateRepository = new PlateRepository(_plateDataConfig.PlateSOList);
        ServiceLocator.RegisterService<IPlateRepository>(plateRepository);
    }

    private void PrepareLevelHealthService()
    {
        _levelHealthService = new LevelHealthService();
        ServiceLocator.RegisterService<LevelHealthService>(_levelHealthService);
        _levelHealthService.OnHealthEnd += HealthEndHandler;
    }

    private void PrepareEndLevelService()
    {
        _endLevelService = new EndLevelService(_endLevelView);
    }

    private void InitServices()
    {
        _waveService.Init(_waveConfig);
        _dragAndDropInventoryService.Init(_inventoryConfig);
        _levelHealthService.SetHealth(_levelHeatlh);
    }

    private void Awake()
    {
        PrepareShopService();
        PrepareInventoryService();
        PrepareEnemyRepository();
        PreparePlateRepository();
        PrepareLevelHealthService();
        PrepareEndLevelService();
    }

    private void Start()
    {
        _dragAndDropInventoryService.OnEndDragPanel += EndDragHandler;
        _dragAndDropInventoryService.OnStartDragPanel += StartDragHandler;

        _shopService.OnPlateBuy += PlateBuyHandler;

        GameEvents.OnAddGold += AddGoldHandler;
        GameEvents.OnStartWave += StartWaveHandler;
        GameEvents.OnEndWave += EndWaveHandler;

        InitServices();
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
        _levelHealthService.OnHealthEnd += HealthEndHandler;

        ServiceLocator.RemoveService<ShopService>();
        ServiceLocator.RemoveService<InventoryService>();
        ServiceLocator.RemoveService<IEnemyRepository>();
        ServiceLocator.RemoveService<IPlateRepository>();
        ServiceLocator.RemoveService<LevelHealthService>();

        GameEvents.OnAddGold -= AddGoldHandler;
        GameEvents.OnStartWave -= StartWaveHandler;
        GameEvents.OnEndWave -= EndWaveHandler;
    }
}