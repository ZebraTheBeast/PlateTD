using PlateTD.Inventory;

namespace PlateTD.Entities
{
    public class PlateInventoryData
    {
        public PlateInventoryData(InventoryPlatePanel inventoryPlatePanel, int amount = 0)
        {
            InventoryPlatePanel = inventoryPlatePanel;
            Amount = amount;
        }

        public InventoryPlatePanel InventoryPlatePanel { get; set; }
        public int Amount { get; set; }
    }
}