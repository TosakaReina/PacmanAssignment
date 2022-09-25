using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMoveDemo : MonoBehaviour
{

    [SerializeField]
    private GameObject item;
    private Tweener tweener;

    private float elapsedTime;

    private Vector3 bottomRight = new Vector3(-8.0f,9.0f,0.0f);
    private Vector3 bottomLeft = new Vector3(-13.0f,9.0f,0.0f);
    private Vector3 topLeft = new Vector3(-13.0f,13.0f,0.0f);
    private Vector3 topRight = new Vector3(-8.0f,13.0f,0.0f);

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
    }

    // Update is called once per frame
    void Update()
    {
        if(item.transform.position == bottomRight)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomLeft, 2.5f);
        }else if(item.transform.position == bottomLeft)
        {
            tweener.AddTween(item.transform, item.transform.position, topLeft, 2.0f);
        }else if(item.transform.position == topLeft)
        {
            tweener.AddTween(item.transform, item.transform.position, topRight, 2.5f);
        }else if(item.transform.position == topRight)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomRight, 2.0f);
        }
        elapsedTime += Time.deltaTime;
        if(elapsedTime - 0.5f < 0.1f && elapsedTime - 0.5f > 0.0f)
        {
            GameObject.Find("eating pellet").GetComponent<AudioSource>().Play();
            elapsedTime = 0.0f;
        }
    }
}
 