using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZP.ObjectStats;
using System.Runtime.InteropServices.WindowsRuntime;

public class StatsHolder : MonoBehaviour
{
    public Stats stats;
    private Dictionary<int, Stat> statValues = new Dictionary<int, Stat>();
    
    private void Start()
    {
        stats = new Stats();
        
    }

    public void AddBuff()
    {
        
    }

    public void RemoveBuff() 
    { 
    
    }

    public void ChangeStatBy(StatType statType, float value)
    {
        int statTypeIndex = GetStatTypeIndex(statType);
        stats.ChangeStatValueBy(statTypeIndex, value);
        Stat targetStat = statValues[statTypeIndex];
        targetStat.isCalculated = false;
        statValues[statTypeIndex] = targetStat;
    }
    
    private int GetStatTypeIndex(StatType type)
    {
        return (int)type;
    }

    public void CreateStat(StatType statType, float statValue = 0)
    {
        try
        {
            int statTypeIndex = GetStatTypeIndex(statType);
            Debug.Log("try");
            statValues.Add(statTypeIndex, new Stat(statType, statValue));
            Debug.Log("ing");
            stats.ConstructStat(statType, statValue);
            Debug.Log("success!");

        }
        catch (System.Exception)
        {
            Debug.LogError("Couldn't create stat.");
            throw;
        }
       
    }

    public void CreateModifier(string statName, StatType statType, float statValue)
    {
        stats.ConstructModifier(statName, statType, statValue);
    }

    public float GetStatValue(int statID)
    {
        Stat stat = statValues[statID];
        if (stat.isCalculated) return stat.value;

        CalculateStat(statID);
        return statValues[statID].value;
    }

    public float GetStatValue(StatType statType)
    {
        int statID = GetStatTypeIndex(statType);
        Stat stat = statValues[statID];
        if (stat.isCalculated) return stat.value;

        CalculateStat(statID);
        return statValues[statID].value;
    }

    public Stat GetStat(int statID)
    {
        Stat stat = statValues.ContainsKey(statID) ? statValues[statID] : new Stat(StatType.HealthPoints, 0);
        return stat;

    }

    public float GetModifierValue(string modifierName)
    {
        return stats.modifiers[modifierName].value;
    }

    private void CalculateStat(int statID)
    {
        if(!statValues.ContainsKey(statID)) return;

        Stat targetStat = stats.GetStat(statID);
        targetStat.value = stats.CalculateStat(statID);
        targetStat.isCalculated = true;
        statValues[statID] = targetStat;
        
        
    }

    public bool HasStatType(StatType statType)
    {
        return statValues.ContainsKey(GetStatTypeIndex(statType));
    }

    public string GetStatNameFromIndex(int statIndex)
    {
        StatType newStatType = (StatType)statIndex;
        return newStatType.ToString();
    }

    public float GetBaseStatValue(StatType statType)
    {
        stats.stats.TryGetValue(GetStatTypeIndex(statType), out Stat baseStat);
        return baseStat.value;
    }

   

    

    public class StatContainer
    {
        public Stat stat;

        
    }
}
