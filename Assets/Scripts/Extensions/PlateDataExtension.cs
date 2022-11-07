using PlateTD.Entities;
using PlateTD.SO;

namespace PlateTD.Extensions
{
    public static class PlateDataExtension
    {
        public static DamageDebuffData ToDamageDebuffData(this PlateData plateData)
        {
            return new DamageDebuffData
            {
                Damage = plateData.Damage,
                Debuff = plateData.Debuff
            };
        }
    }
}