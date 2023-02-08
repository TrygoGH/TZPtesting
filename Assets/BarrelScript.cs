using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TZP.ObjectStats;
using static TZP.ObjectStats.StatType;

public class BarrelScript : MonoBehaviour
{
    public StatsHolder stats;
    // Start is called before the first frame update

    private void Awake()
    {
        stats = GetComponent<StatsHolder>();
    }
    void Start()
    {
        stats.CreateStat(HealthPoints, 10);
        //stats.CreateStat(MaxHealthPoints, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if(stats.GetStatValue(HealthPoints) <= 0)
        {
            Destroy(gameObject);
        }
    }
}
