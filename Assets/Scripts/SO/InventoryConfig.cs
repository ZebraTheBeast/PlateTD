using System.Collections.Generic;
using PlateTD.Entities.DTO;
using UnityEngine;

namespace PlateTD.SO
{
    [CreateAssetMenu(fileName = "InventoryConfig", menuName = "PlateTD/InventoryConfig", order = 0)]
    public class InventoryConfig : ScriptableObject
    {
        public List<PlateInventoryDTO> StartPlates;
    }
}