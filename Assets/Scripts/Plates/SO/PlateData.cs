using PlateTD.Debuffs;
using UnityEngine;

[CreateAssetMenu(fileName = "PlateData", menuName = "PlateTD/PlateData", order = 0)]
public class PlateData : ScriptableObject
{
    public string Name;
    public float Damage;
    public float ReloadSpeed;
    public DebuffData Debuff;
    public PlateData NextLevelPlate;
    public int PlatesToLevelUp;
}