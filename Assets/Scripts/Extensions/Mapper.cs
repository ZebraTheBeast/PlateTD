using System.Collections.Generic;
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

        public static List<PlateInventoryDTO> ToPlateInventoryDTO(this PlateDataConfig plateDataConfig)
        {
            var plateInventoryDTOs = new List<PlateInventoryDTO>();

            foreach (var plateSO in plateDataConfig.PlateSOList)
            {
                plateInventoryDTOs.Add(
                    new PlateInventoryDTO
                    {
                        Type = plateSO.PlateType,
                        Sprite = plateSO.Sprite
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
    }
}