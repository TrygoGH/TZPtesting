using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicObject : MonoBehaviour
{
    public GameObject target;
    public bool moveTowardsTarget;
    public float moveValue;
    public enum MovementTypes
    { 
        None,
        Speed,
        Lerp,
        Time,
        Velocity,
    }
    public MovementTypes movementType;



    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);
            if (moveTowardsTarget) { Move(); } 
                
       
        }
        
    }

    private void Move(float lerp = 1)
    {
        switch (movementType)
        {
            case MovementTypes.None:
                break;
            case MovementTypes.Speed:
                transform.position += moveValue * Time.deltaTime * transform.forward;
                break;
            case MovementTypes.Lerp:
                break;
            case MovementTypes.Time:
                break;
            case MovementTypes.Velocity:
                break;
            default:
                break;
        }
    }

    private void LookTowardsTarget(GameObject target)
    {

    }
}
