using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timer
{
    private float startTime;
    private float duration;
    public bool isMilliseconds = false;

    public Timer(float duration)
    {
        startTime = Time.time;
        this.duration = duration;
    }

    public void SetTimerDuration(float duration)
    {
        startTime = Time.time;
        this.duration = duration;
    }



    public bool IsFinished()
    {
        if (isMilliseconds) return Time.time - startTime >= duration / 1000;

        return Time.time - startTime >= duration;
    }

    public float GetTimeLeft()
    {
        if(isMilliseconds) return Mathf.Max(duration / 1000 - (Time.time - startTime), 0);

        return Mathf.Max(duration - (Time.time - startTime), 0);
    }
}