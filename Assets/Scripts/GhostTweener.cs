using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostTweener : MonoBehaviour
{
    public List<Tween> activeTweens;

    private float elapsedTime;

    void Start()
    {
        activeTweens = new List<Tween>();
    }

    void Update()
    {
        if (activeTweens != null)
        {

            for (int i = 0; i < activeTweens.Count; i++)
            {
                float distance = Vector3.Distance(activeTweens[i].Target.position, activeTweens[i].EndPos);
                elapsedTime += Time.deltaTime;
                float timeFraction = elapsedTime / activeTweens[i].Duration;

                if (distance > 0.1f)
                {
                    activeTweens[i].Target.position = Vector3.Lerp(activeTweens[i].StartPos, activeTweens[i].EndPos, timeFraction);
                }
                else
                {
                    activeTweens[i].Target.position = activeTweens[i].EndPos;
                    elapsedTime = 0.0f;
                    activeTweens.Remove(activeTweens[i]);
                }
            }
        }
    }

    public bool AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {

        if (!TweenExists(targetObject))
        {
            activeTweens.Add(new Tween(targetObject, startPos, endPos, Time.time, duration));
            return true;
        }
        return false;
    }

    public bool TweenExists(Transform target)
    {
        foreach (Tween t in activeTweens)
        {
            if (t.Target == target)
            {
                return true;
            }
        }
        return false;
    }

}