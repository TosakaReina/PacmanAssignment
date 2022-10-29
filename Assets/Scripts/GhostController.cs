using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public GhostTweener ghostsTweeners;
    public GameObject Ghost4;
    public GameObject G4GoOutsidePoints;
    public GameObject G4ClockwisePoints;

    private List<Vector3> outsidePoints = new List<Vector3>();
    private List<Vector3> clockwisePoints = new List<Vector3>();
    private int G4index = 0;
    private int G4Clockwiseindex = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform PointTf in G4GoOutsidePoints.transform)
        {
            outsidePoints.Add(PointTf.position);
        }
        foreach (Transform PointTf in G4ClockwisePoints.transform)
        {
            clockwisePoints.Add(PointTf.position);
        }
        Debug.Log(clockwisePoints.Count);
    }

    private void FixedUpdate()
    {
        if (G4index < outsidePoints.Count - 1)
        {
            G4GoOutside();
        }
        else if(G4index == outsidePoints.Count - 1)
        {
            G4Clockwise();
            Debug.Log(G4Clockwiseindex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void G4GoOutside()
    {
        if(Ghost4.transform.position == outsidePoints[G4index])
        {
            float distance = (Ghost4.transform.position - outsidePoints[G4index + 1]).magnitude;
            float duration = distance * 0.25f;
            ghostsTweeners.AddTween(Ghost4.transform, Ghost4.transform.position, outsidePoints[G4index + 1], duration);
            if (G4index < outsidePoints.Count - 1)
            {
                G4index++;
            }
        }
    }

    void G4Clockwise()
    {
        if (Ghost4.transform.position == clockwisePoints[G4Clockwiseindex])
        {
            if (G4Clockwiseindex < clockwisePoints.Count - 1)
            {
                float distance = (Ghost4.transform.position - clockwisePoints[G4Clockwiseindex + 1]).magnitude;
                float duration = distance * 0.25f;
                ghostsTweeners.AddTween(Ghost4.transform, Ghost4.transform.position, clockwisePoints[G4Clockwiseindex + 1], duration);
            }else if(G4Clockwiseindex == clockwisePoints.Count - 1)
            {
                float distance = (Ghost4.transform.position - clockwisePoints[0]).magnitude;
                float duration = distance * 0.25f;
                ghostsTweeners.AddTween(Ghost4.transform, Ghost4.transform.position, clockwisePoints[0], duration);
            }
            G4Clockwiseindex = (G4Clockwiseindex + 1) % clockwisePoints.Count;
        }
    }
}
