using PlateTD.Enemies.Interfaces;
using PlateTD.Entities.DTO;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.Repositories.Interfaces
{
    public interface IPlateRepository
    {
        PlateBuildingDTO GetPlateBuildingDTOByPlateType(PlateType type);
        GameObject GetPlateAppearanceByPlateType(PlateType type);
        Sprite GetPlateSpriteByType(PlateType type);
    }
}