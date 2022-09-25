using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween
{
    public Transform Target { get; }
    public Vector3 StartPos { get; }
    public Vector3 EndPos { get; }
    public float StartTime { get; }
    public float Duration { get; }

    //constructor
    public Tween(Transform tagert, Vector3 sp, Vector3 ep, float st, float duration)
    {
        Target = tagert;
        StartPos = sp;
        EndPos = ep;
        StartTime = st;
        Duration = duration;
    }

}