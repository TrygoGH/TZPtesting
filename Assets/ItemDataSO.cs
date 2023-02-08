using TZP.ObjectStats;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static TZP.ObjectStats.StatType;

[CreateAssetMenu]
public class ItemDataSO : ScriptableObject
{
    public new string name; 
    public Stats stats;
    public Sprite sprite;
    [SerializeField] private GameObject itemGameObject;
    public GameObject Owner
    {
        get { return _owner; }
        set 
        { 
            if(itemGameObject != null) itemGameObject.transform.SetParent(value.transform); 
            _owner = value;
        }
    }
    [SerializeField] private GameObject _owner;

    public float PhysicalMult
    {
        get { return physicalMultiplierStat.value; }
        set { physicalMultiplierStat.value = value;}
    }
    [SerializeField] private float _physicalMult;

    public float MagicMult
    {
        get { return magicMultiplierStat.value; }
        set { magicMultiplierStat.value = value;}
    }
    [SerializeField] private float _magicMult;

    public float TrueMult
    {
        get { return trueMultiplierStat.value; }
        set { trueMultiplierStat.value = value;}
    }
    [SerializeField] private float _trueMult;

    private MultiplierStat physicalMultiplierStat;
    private MultiplierStat magicMultiplierStat;
    private MultiplierStat trueMultiplierStat;
    
    public float AttackDmg
    {
        get { return _attackDmg; }
        set
        {
            if (stats.HasStat(AttackDamage)) stats.SetStatValueTo(AttackDamage, value);
            _attackDmg = value;
        }
    }
    [SerializeField] private float _attackDmg;
    public float AttackSpd
    {
        get { return _attackSpd; }
        set
        {
            if(stats.HasStat(AttackSpeed)) stats.SetStatValueTo(AttackSpeed, value);
            _attackSpd = value;
        }
    }
    [SerializeField] private float _attackSpd;


    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    public ItemDataSO()
    {
        stats = new Stats();
        InitStats();
    }

    public float ValueOf(StatType statType)
    {
        return stats.GetStatValue(statType);
    }
    
    private void InitStats()
    {
        stats.ConstructStat(AttackDamage, _attackDmg);
        stats.ConstructStat(AttackSpeed, _attackSpd);
    }

    

}

public struct MultiplierStat
{
    public float value;
    public enum DamageType
    {
        Physical = 0,
        Magic,
        True,
    }

    public enum RangeType
    {
        Melee = 0,
        Short,
        Medium,
        Long,
    }

    public DamageType damageType;
    public RangeType rangeType;

    public MultiplierStat(float multiplierValue, DamageType typeOfDamage = 0, RangeType typeOfRange = 0)
    {
        damageType = typeOfDamage;
        rangeType = typeOfRange;
        value = multiplierValue;
    }
}

