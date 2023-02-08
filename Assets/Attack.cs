using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZP.ObjectStats;
using static TZP.ObjectStats.StatType;
using System.Linq;
using System;

namespace TZP.ObjectStats.Attack
{
    public enum AttackTypes
    {
        Melee,
        Ranged,
        Mixed,
    }
    public enum DamageTypes
    {
        Physical,
        Magic,
        True,
        Mixed,
    }

    public readonly struct Attack
    {
        public readonly string name;
        public readonly AttackTypes attackType;
        public readonly DamageTypes effectType;
        public readonly List<ModifierStat> effects;
        public readonly List<ModifierStat> statuses;
        public readonly List<Stat> rawDamages;
        public readonly List<Stat> rawEffects;
        public readonly float physicalDamage;
        public readonly float magicDamage;
        public readonly float trueDamage;

        public Attack(float value)
        {
            name = string.Empty;
            attackType = AttackTypes.Melee;
            effectType = DamageTypes.Magic;
            effects = new List<ModifierStat>();
            statuses = new List<ModifierStat>();
            rawDamages = new List<Stat>();
            rawEffects = new List<Stat>();
            physicalDamage = 0;
            magicDamage = 0;
            trueDamage = 0;

            effects.Add(new ModifierStat(HealthPoints, value));

        }
        public float CalculateRawDamage(StatsHolder targetStats)
        {
            if (targetStats == null) return 0;
            float targetCurrentHp = targetStats.HasStatType(HealthPoints) ? targetStats.GetStatValue(HealthPoints) : 0;
            float targetCurrentMaxHp = targetStats.HasStatType(MaxHealthPoints) ? targetStats.GetStatValue(MaxHealthPoints) : 0;

            rawDamages.Clear();
            foreach (ModifierStat effect in effects)
            {
                switch (effect.modType)
                {
                    case ModifierType.Flat:
                        rawDamages.Add(new Stat(effect));
                        break;
                    case ModifierType.Multiplicative:
                        rawDamages.Add(new Stat(effect));
                        break;
                    case ModifierType.Additive:
                        rawDamages.Add(new Stat(effect));
                        break;
                    default:
                        break;
                }
            }
            float damage = rawDamages.Sum(x => Convert.ToInt32(x.value));
            return damage;
        }

        public Damage CreateDamageStruct(StatsHolder stats)
        {
            return new Damage(CalculateRawDamage(stats), attackType, effectType);
        }
    }

    public readonly struct Damage
    {
        public readonly float value;
        public readonly AttackTypes attackType;
        public readonly DamageTypes damageType;

        public Damage(float damage, AttackTypes typeOfAttack, DamageTypes typeOfDamage)
        {
            value = damage;
            attackType= typeOfAttack;
            damageType = typeOfDamage;
        }
    }
}
