using PlateTD.Enemies.Interfaces;
using PlateTD.SO;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IEnemy
{
    private float _currentHP;
    private float _movementSpeed;


    public void ConsumeDamage(float damage)
    {
        Debug.Log($"get {damage} dmg");
    }

    public void ConsumeDebuff(DebuffSO debuff)
    {
        Debug.Log($"get {debuff.Type} debuff");
    }
}
