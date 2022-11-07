using PlateTD.Extensions;
using PlateTD.Plates.Affectors;

namespace PlateTD.Plates.Behaviours
{
    public class DamageDebuffPlateBehaviour : PlateBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            _plateAffector = new DamageDebuffAffector();
            _plateAffector.SetData(_plateData.ToDamageDebuffData());
        }
    }
}