using PlateTD.Plates.Affectors;

namespace PlateTD.Plates.Behaviours
{
    public class DamagePlateBehaviour : PlateBehaviour
    {
        protected override void Awake()
        {  
            base.Awake();
            _plateAffector = new DamageAffector();
        }
    }
}