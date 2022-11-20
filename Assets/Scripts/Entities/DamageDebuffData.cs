using PlateTD.Entities.Enums;
using PlateTD.SO;

namespace PlateTD.Entities
{
    public class DamageDebuffData
    {
        public DebuffSO Debuff { get; set; }
        public float Damage { get; set; }
        public PlateType PlateType {get;set;}
}
}