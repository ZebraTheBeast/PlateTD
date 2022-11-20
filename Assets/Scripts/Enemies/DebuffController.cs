using System.Collections.Generic;
using System.Linq;
using PlateTD.Entities.DTO;
using PlateTD.Entities.Enums;
using UnityEngine;

namespace PlateTD.Enemies
{
    public class DebuffController
    {
        private const float DamageMultiplier = 2f;

        private float _stopSpeed;

        private Dictionary<DebuffType, DebuffDTO> _debuffs;

        private float _damagePerTime;
        private float _timer;

        public DebuffController(float stopSpeed, float damagePerTime)
        {
            _stopSpeed = stopSpeed;
            _damagePerTime = damagePerTime;
            _debuffs = new Dictionary<DebuffType, DebuffDTO>();
        }

        public void AddDebuff(DebuffType type, DebuffDTO debuffData)
        {
            if (_debuffs.ContainsKey(type) &&
                _debuffs[type].DebuffLevel > debuffData.DebuffLevel)
            {
                _debuffs[type].Time = debuffData.Time;
            }
            else
            {
                _debuffs[type] = debuffData;
                AffectOtherDebuffs(type);
            }
        }

        public void Tick(float delta, out float totalDamage, out float totalSpeedSlow)
        {
            var dealDamage = false;
            totalDamage = 0f;
            totalSpeedSlow = 0f;

            _timer -= delta;

            if (_timer < 0)
            {
                dealDamage = true;
                _timer = _damagePerTime;
            }

            foreach (var debuff in _debuffs)
            {
                if (dealDamage)
                {
                    totalDamage += debuff.Value.Damage;
                }

                totalSpeedSlow += debuff.Value.Speed;

                debuff.Value.Time -= delta;
            }

            var debuffsToRemove = _debuffs.Where(debuff => debuff.Value.Time <= 0).ToArray();
            foreach (var debuff in debuffsToRemove)
            {
                _debuffs.Remove(debuff.Key);
            }

            totalSpeedSlow = Mathf.Clamp(totalSpeedSlow, 0, _stopSpeed);
        }

        private void AffectOtherDebuffs(DebuffType debuffType)
        {
            switch (debuffType)
            {
                case DebuffType.InFire:
                    if (_debuffs.ContainsKey(DebuffType.InWater))
                    {
                        _debuffs.Remove(DebuffType.InWater);
                    }
                    if (_debuffs.ContainsKey(DebuffType.Cold))
                    {
                        _debuffs.Remove(DebuffType.Cold);
                    }
                    break;
                case DebuffType.InWater:
                    if (_debuffs.ContainsKey(DebuffType.Cold))
                    {
                        _debuffs[DebuffType.Cold].Damage *= DamageMultiplier;
                    }
                    if (_debuffs.ContainsKey(DebuffType.InFire))
                    {
                        _debuffs.Remove(DebuffType.InFire);
                    }
                    break;
                case DebuffType.Cold:
                    if (_debuffs.ContainsKey(DebuffType.InWater))
                    {
                        _debuffs[DebuffType.InWater].Damage *= DamageMultiplier;
                    }
                    if (_debuffs.ContainsKey(DebuffType.InFire))
                    {
                        _debuffs.Remove(DebuffType.InFire);
                    }
                    break;
                case DebuffType.Shocked:
                    if (_debuffs.ContainsKey(DebuffType.InWater))
                    {
                        _debuffs[DebuffType.Shocked].Damage *= DamageMultiplier;
                    }
                    break;
                default:
                    // no action 
                    break;
            }
        }
    }
}