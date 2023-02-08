using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawn;
using TZP.ObjectStats;
using static TZP.ObjectStats.StatType;
using JetBrains.Annotations;
using TZP.ObjectStats.Attack;

public class CharacterScript : MonoBehaviour
{
    public SpawnScript spawn;

    StatsHolder stats;
    public Damagable damage;
    public Hitable hitable;
    // Start is called before the first frame update

    private void Awake()
    {
        spawn = GetComponent<SpawnScript>();   
        if(spawn == null) gameObject.AddComponent<SpawnScript>();
        stats = GetComponent<StatsHolder>();
        spawn.CreateSpawn("Home", new Vector3(0, 5, 0), Vector3.one, true, true) ;
        
    }

    void Start()
    {

        spawn.Spawn();
        stats.CreateStat(HealthPoints, 10);
       







    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) || transform.position.y < -50)
        {
            //stats.ChangeStatBy("hi", 1);
            spawn.Spawn();
            //damage.TakeDamage(new Damage(1, AttackTypes.Melee, DamageTypes.Physical));
            hitable.Attacked(new Attack(5));
            Debug.Log(stats.GetStatValue(HealthPoints));
        }

        //Debug.Log(stats.GetStat("hi").isCalculated);
        //stats.GetStatValue("hi");

        Physics.SphereCast(transform.position, 2, Vector3.right, out RaycastHit hit);
        if (hit.transform != null)
        {
            hit.transform.gameObject.TryGetComponent<Hitable>(out Hitable target);
            if (target != null)
            {
                target.Attacked(new Attack(1));
            }
        }
        

        

    }
}
