using Spawn;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;



namespace TZP.ObjectStats
{
    public enum StatType
    {
        HealthPoints,
        MaxHealthPoints,
        HealthRegen,
        HealthDegen,

        ManaPoints,
        MaxManaPoints,
        ManaRegen,
        ManaDegen,

        AttackDamage,
        AttackSpeed,

        Armor,
        PhysicalReduction,
        MagicResistance,
        MagicReduction,


    }

    public enum ModifierType
    {
        Flat,
        Multiplicative,
        Additive
    }

    public class Stats
    {
        public readonly Dictionary<int, Stat> stats = new Dictionary<int, Stat>();
        public readonly Dictionary<string, ModifierStat> modifiers = new Dictionary<string, ModifierStat>();


        public Stats()
        {
            InitStats();
        }

        public void ChangeStatValueBy(int statID, float valueChange)
        {
            Stat newStat = stats[statID];
            newStat.value += valueChange;
            stats[statID] = newStat;
        }

        public void SetStatValueTo(int statID, float valueChange)
        {
            Stat newStat = stats[statID];
            newStat.value = valueChange;
            stats[statID] = newStat;
        }

        public void SetStatValueTo(StatType statType, float valueChange)
        {
            int statID = (int)statType;
            Stat newStat = stats[statID];
            newStat.value = valueChange;
            stats[statID] = newStat;
        }

        public void ConstructStat(StatType statType, float statValue = 0)
        {
            AddNewStat((int)statType, new Stat(statType, statValue));
        }

        public void ConstructStats(StatType[] statTypes, float statValue = 0)
        {
            foreach (StatType statType in statTypes)
            {
                AddNewStat((int)statType, new Stat(statType, statValue));
            }
            
        }

        public void TryInitStats(StatType[] statTypes, float statValue = 0)
        {
            foreach (StatType statType in statTypes)
            {
                if (!stats.ContainsKey((int)statType))
                {
                    AddNewStat((int)statType, new Stat(statType, statValue));
                }
            }

        }
        
        public void ConstructStat(int statTypeIndex, float statValue = 0)
        { 
            AddNewStat(statTypeIndex, new Stat((StatType)statTypeIndex, statValue));
        }

        public void ConstructModifier(string statName, StatType statType, float statValue = 0)
        {
            AddNewMod(statName, new ModifierStat(statType, statValue));
        }

        public Stat GetStat(int statID)
        {
            stats.TryGetValue(statID, out Stat stat);
            return stat;
        }

        public Stat GetStat(StatType statType)
        {
            stats.TryGetValue((int)statType, out Stat stat);
            return stat;
        }

        public float GetStatValue(int statID)
        {
            return GetStat(statID).value;
        }

        public float GetStatValue(StatType statType)
        {
            return GetStat(statType).value;
        }

        private void AddNewStat(int statID, Stat stat)
        {
            stats.Add(statID, stat);
        }   

        private void AddNewMod(string statName, ModifierStat modStat)
        {
            modifiers.Add(statName, modStat);
        }

        public void InitStats()
        {
            stats.Clear();
        }

        public bool HasStat(StatType statType)
        {
            return stats.ContainsKey((int)statType);
        }

        public float CalculateStat(int statID)
        {

            Stat targetStat = stats[statID];
            StatType targetStatType = targetStat.type;
            float targetStatValue = targetStat.value;
            float calculatedStatValue = targetStat.value;
            foreach (ModifierStat modifier in modifiers.Values)
            {
                if (modifier.type == targetStatType)
                {

                    switch (modifier.modType)
                    {
                        case ModifierType.Flat:
                            calculatedStatValue += modifier.value;
                            break;
                        case ModifierType.Multiplicative:
                            calculatedStatValue *= modifier.value;
                            break;
                        case ModifierType.Additive:
                            calculatedStatValue += calculatedStatValue * modifier.value;
                            break;
                        default:
                            Debug.LogError("Stat modifier " + modifier.modType + " is unknown. The modifier was not applied to the target stat.");
                            break;
                    }
                }
            }
            return calculatedStatValue; 



        }

    }

    public struct Stat
    {

        public float value;
        public StatType type;
        public bool isCalculated;

        public Stat(StatType statType, float statValue, bool calculated = false)
        {
            type = statType;
            value = statValue;
            isCalculated = calculated;
            
        }

        public Stat(ModifierStat modStat)
        {
            type = modStat.type;
            value = modStat.value;
            isCalculated = false; 
        }
    }

    public struct ModifierStat
    {

        public float value;
        public StatType type;
        public ModifierType modType;

        public ModifierStat(StatType statType, float statValue, ModifierType statModType = ModifierType.Flat)
        {
            type = statType;
            value = statValue;
            modType = statModType;
            

        }
    }

    public class Buff
    {
        Timer buffTimer;

        public Buff(float timerDuration)
        {
            buffTimer = new Timer(timerDuration);
        }

    }


}



