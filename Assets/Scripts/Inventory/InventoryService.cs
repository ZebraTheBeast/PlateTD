using System;
using System.Collections.Generic;
using PlateTD.Entities.Enums;
using PlateTD.SO;

public class InventoryService
{
    private Dictionary<PlateType, int> _inventory;

    public event Action<PlateType, int> OnPlateTypeAmountChanged;

    public InventoryService(InventoryConfig inventoryConfig)
    {
        _inventory = new Dictionary<PlateType, int>();

        foreach (var plateData in inventoryConfig.StartPlates)
        {
            _inventory.Add(plateData.Type, plateData.Amount);
        }
    }

    public int GetPlateAmount(PlateType plateType)
    {
        return _inventory.ContainsKey(plateType) ? _inventory[plateType] : 0;
    }

    public void AddPlate(PlateType plateType)
    {
        if (_inventory.ContainsKey(plateType))
        {
            _inventory[plateType]++;
        }
        else
        {
            _inventory.Add(plateType, 1);
        }

        OnPlateTypeAmountChanged?.Invoke(plateType, _inventory[plateType]);
    }

    public void ReducePlate(PlateType plateType)
    {
        if (_inventory.ContainsKey(plateType))
        {
            _inventory[plateType]--;
            OnPlateTypeAmountChanged?.Invoke(plateType, _inventory[plateType]);
        }
        else
        {
            throw new Exception($"[{this.GetType().Name}][ReducePlate] Can not find plate with type: {plateType}");
        }
    }
}