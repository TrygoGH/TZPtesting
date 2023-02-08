using System.Collections;
using System.Collections.Generic;
using TZP.ObjectStats.Attack;
using TZP.ObjectStats;
using static TZP.ObjectStats.StatType;
using UnityEngine;
using System;

[RequireComponent(typeof(StatsHolder))]
public class Damagable : MonoBehaviour
{
    public StatsHolder objectStats;
    private Hitable hitable;

    private void Start()
    {
        objectStats = GetComponent<StatsHolder>();
        InitStats();
        hitable = TryGetComponent<Hitable>(out Hitable hitableComponent) ? hitableComponent : null;
        if(hitable != null)
        {
            hitable.GotAttacked += Attacked;
        }


    }

    public void TakeDamage(Damage damage)
    {
        objectStats.ChangeStatBy(HealthPoints, -Mathf.Abs(damage.value));
    }

    public void Attacked(Attack attack)
    {
        TakeDamage(attack.CreateDamageStruct(objectStats));
        Debug.Log("attacke");
    }

    private void InitStats()
    {
        StatType[] statTypes =
        {
            HealthPoints,
            MaxHealthPoints,
            Armor,
            PhysicalReduction
        };

        Debug.Log(objectStats);
        
    }
}
