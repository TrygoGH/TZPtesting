using System;
using System.Collections;
using System.Collections.Generic;
using TZP.ObjectStats.Attack;
using UnityEngine;

public class Hitable : MonoBehaviour
{
    // Start is called before the first frame update
    public event Action GotHit;
    public event Action<Attack> GotAttacked;
    public void Hit()
    {
        GotHit?.Invoke();
    }

    public void Attacked(Attack attack)
    {
        Debug.Log("hitactive");
        GotAttacked?.Invoke(attack);
        Debug.Log("gothit");
    }
}
