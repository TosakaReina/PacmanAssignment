using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    public GameObject Cherry;
    public Camera Cam;
    private float xPos;
    private float yPos;
    private Vector3 randomPos;
    public GameObject CloneCherry;
    public bool destroyed = false;

    private float elapsedTime;
    private float times = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomSpawn();
        if (!destroyed)
        {
            moveCherry();
            destroyClone();
        }

    }

    void RandomSpawn()
    {
        times -= Time.deltaTime;
        if(times <= 0)
        {
            while (true)
            {
                xPos = Random.Range(-0.5f, 1.5f);
                yPos = Random.Range(-0.5f, 1.5f);
                if(xPos < 0 || xPos > 1 || yPos < 0 || yPos > 1)
                {
                    break;
                }
            }
            randomPos = Cam.ViewportToWorldPoint(new Vector3(xPos, yPos, Cam.nearClipPlane));
            CloneCherry = Instantiate(Cherry, randomPos, Quaternion.identity);

            times = 10.0f;
            elapsedTime = 0.0f;
            destroyed = false;
        }
    }

    void moveCherry()
    {
        Vector3 destination = Cam.ViewportToWorldPoint(new Vector3(1 - xPos, 1 - yPos, Cam.nearClipPlane));
        elapsedTime += Time.deltaTime;
        float timeFraction = elapsedTime / 10.0f;
        CloneCherry.transform.position = Vector3.Lerp(randomPos, destination, timeFraction);
    }

    void destroyClone()
    {
        if(elapsedTime > 5.0f)
        {
            Vector3 cloneViewPos = Cam.WorldToViewportPoint(CloneCherry.transform.position);
            if(cloneViewPos.x < 0 || cloneViewPos.x > 1 || cloneViewPos.y < 0 || cloneViewPos.y > 1)
            {
                destroyed = true;
                Destroy(CloneCherry);
            }
        }
    }

    


}


