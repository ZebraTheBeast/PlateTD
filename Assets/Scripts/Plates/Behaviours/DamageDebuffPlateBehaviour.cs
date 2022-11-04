using PlateTD.Plates;
using UnityEngine;

public class DamageDebuffPlateBehaviour : PlateBehaviour
{
    protected override void Awake()
    {
        base.Awake();
        _plateAffector = new DamageDebuffAffector();
        _plateAffector.SetData(_plateData.ToDamageDebuffData());
    }
}