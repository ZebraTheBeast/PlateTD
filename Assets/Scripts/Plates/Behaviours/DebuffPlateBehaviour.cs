using PlateTD.Plates.Affectors;

namespace PlateTD.Plates.Behaviours
{
    public class DebuffPlateBehaviour : PlateBehaviour
    {
        protected override void Awake()
        {  
            base.Awake();
            _plateAffector = new DebuffAffector();
        }
    }
}