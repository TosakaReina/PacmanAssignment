using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    
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
            float distance = Vector3.Distance(activeTween.Target.position, activeTween.EndPos);
            elapsedTime += Time.deltaTime;
            float timeFraction = elapsedTime / activeTween.Duration;

            activeTween.Target.position = Vector3.Lerp(activeTween.StartPos, activeTween.EndPos, timeFraction);
            if(distance < 0.1)
            {
                activeTween.Target.position = activeTween.EndPos;
                elapsedTime = 0.0f;
                activeTween = null;
            }
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
