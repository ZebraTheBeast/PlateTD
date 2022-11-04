using System.Collections;
using System.Collections.Generic;
using PlateTD.Debuffs;
using PlateTD.Enemies.Interfaces;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IEnemy
{
    public void ConsumeDamage(float damage)
    {
        Debug.Log($"get {damage} dmg");
    }

    public void ConsumeDebuff(DebuffData debuff)
    {
        Debug.Log($"get {debuff.Type} debuff");
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
