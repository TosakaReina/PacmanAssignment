using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    //public Tween activeTween;
    public Tween activeTween;

    private float elapsedTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Update is called once per frame
    void Update()
    {
        if (activeTween != null)
        {
            elapsedTime += Time.deltaTime;
            float timeFraction = elapsedTime / activeTween.Duration;

            activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
        }

    }

    

    

    public void AddTween(Transform targetObject, Vector3 startPos, Vector3 endPos, float duration)
    {
        if (activeTween == null)
        {
            activeTween = new Tween(targetObject, startPos, endPos, Time.time, duration);
        }
    }



}
