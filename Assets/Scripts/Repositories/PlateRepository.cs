using System;
using System.Collections.Generic;
using System.Linq;
using PlateTD.Enemies.Interfaces;
using PlateTD.Repositories.Interfaces;
using PlateTD.Entities.Enums;
using PlateTD.SO;
using UnityEngine;
using PlateTD.Entities.DTO;
using PlateTD.Extensions;

namespace PlateTD.Repositories
{
    public class PlateRepository : IPlateRepository
    {
        private List<PlateSO> _plates;

        public PlateRepository(List<PlateSO> plates)
        {
            _plates = plates;
        }

        public GameObject GetPlateAppearanceByPlateType(PlateType type)
        {
            var plate = GetPlateByType(type);

            return plate.PlateRenderer;
        }

        public PlateBuildingDTO GetPlateBuildingDTOByPlateType(PlateType type)
        {
            var plate = GetPlateByType(type);

            return plate.ToPlateBuildingDTO();
        }

        public Sprite GetPlateSpriteByType(PlateType type)
        {
            var plate = GetPlateByType(type);

            return plate.Sprite;
        }

        private PlateSO GetPlateByType(PlateType type)
        {
            var plate = _plates.FirstOrDefault(plate => plate.PlateType == type);

            if (plate == null)
            {
                throw new Exception($"[{this.GetType().Name}][GetPlateByType] Can not find plate with type {type}");
            }

            return plate;
        }
    }
}