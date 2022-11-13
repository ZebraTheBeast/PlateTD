using System.Collections.Generic;
using System.Linq;
using PlateTD.Entities;
using PlateTD.Entities.DTO;
using PlateTD.SO;

namespace PlateTD.Extensions
{
    public static class Mapper
    {
        public static DamageDebuffData ToDamageDebuffData(this PlateDTO plateData)
        {
            return new DamageDebuffData
            {
                Damage = plateData.Damage,
                Debuff = plateData.Debuff
            };
        }

        public static List<PlateInventoryViewDTO> ToPlateInventoryViewDTO(this PlateDataConfig plateDataConfig, InventoryConfig inventoryConfig)
        {
            var plateInventoryDTOs = new List<PlateInventoryViewDTO>();

            foreach (var plateSO in plateDataConfig.PlateSOList)
            {
                var amount = inventoryConfig.StartPlates.FirstOrDefault(plate => plate.Type == plateSO.PlateType).Amount;
                plateInventoryDTOs.Add(
                    new PlateInventoryViewDTO
                    {
                        Type = plateSO.PlateType,
                        Sprite = plateSO.Sprite,
                        Amount = amount
                    }
                );
            }

            return plateInventoryDTOs;
        }

        public static PlateBuildingDTO ToPlateBuildingDTO(this PlateSO plateSO)
        {
            return new PlateBuildingDTO
            {
                Prefab = plateSO.Prefab,
                PlateData = plateSO.ToPlateDTO()
            };
        }

        public static PlateDTO ToPlateDTO(this PlateSO plateSO)
        {
            return new PlateDTO
            {
                Damage = plateSO.Damage,
                ReloadSpeed = plateSO.ReloadSpeed,
                Debuff = plateSO.Debuff,
                NextLevelPlate = plateSO.NextLevelPlate?.ToPlateDTO(),
                PlatesToLevelUp = plateSO.PlatesToLevelUp,
                PlateRenderer = plateSO.PlateRenderer,
            };
        }

        public static EnemyDTO ToEnemyDTO(this EnemySO enemySO)
        {
            return new EnemyDTO
            {
                
            };
        }
    }
}