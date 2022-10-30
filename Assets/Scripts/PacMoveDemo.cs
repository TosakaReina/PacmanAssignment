using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacMoveDemo : MonoBehaviour
{

    [SerializeField]
    private GameObject item;
    private Tweener tweener;

    private float elapsedTime;

    private Vector3 bottomRight = new Vector3(8.0f,1.5f,0.0f);
    private Vector3 bottomRight2 = new Vector3(3.0f,1.5f,0.0f);
    private Vector3 bottomRight3 = new Vector3(3.0f,2.0f,0.0f);
    private Vector3 bottomLeft = new Vector3(-6.0f,2.0f,0.0f);
    private Vector3 bottomLeft2 = new Vector3(-2.0f,2.0f,0.0f);
    private Vector3 bottomLeft3 = new Vector3(-2.1f,2.0f,0.0f);
    private Vector3 topLeft = new Vector3(-6.0f,4.2f,0.0f);
    private Vector3 topLeft2 = new Vector3(-2.0f,4.2f,0.0f);
    private Vector3 topLeft3 = new Vector3(-2.1f,4.1f,0.0f);
    private Vector3 topRight = new Vector3(6.0f,4.1f,0.0f);
    private Vector3 topRight2 = new Vector3(6.0f,2.8f,0.0f);
    private Vector3 topRight3 = new Vector3(8.0f,2.8f,0.0f);

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
            tweener.AddTween(item.transform, item.transform.position, bottomRight2, 1.5f);
        }else if(item.transform.position == bottomRight2)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomRight3, 0.25f);
        }else if(item.transform.position == bottomRight3)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomLeft2, 2.0f);
        }else if(item.transform.position == bottomLeft2)
        {
            tweener.AddTween(item.transform, item.transform.position, topLeft2, 1.0f);
        }
        else if (item.transform.position == topLeft2)
        {
            tweener.AddTween(item.transform, item.transform.position, topLeft, 1.5f);
        }
        else if (item.transform.position == topLeft)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomLeft, 1.0f);
        }
        else if (item.transform.position == bottomLeft)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomLeft3, 1.5f);
        }
        else if (item.transform.position == bottomLeft3)
        {
            tweener.AddTween(item.transform, item.transform.position, topLeft3, 1.0f);
        }
        else if (item.transform.position == topLeft3)
        {
            tweener.AddTween(item.transform, item.transform.position, topRight, 2.5f);
        }
        else if (item.transform.position == topRight)
        {
            tweener.AddTween(item.transform, item.transform.position, topRight2, 0.75f);
        }
        else if (item.transform.position == topRight2)
        {
            tweener.AddTween(item.transform, item.transform.position, topRight3, 1.0f);
        }
        else if (item.transform.position == topRight3)
        {
            tweener.AddTween(item.transform, item.transform.position, bottomRight, 0.5f);
        }
        elapsedTime += Time.deltaTime;

        //if(elapsedTime - 0.5f < 0.1f && elapsedTime - 0.5f > 0.0f)
        //{
        //    GameObject.Find("eating pellet").GetComponent<AudioSource>().Play();
        //    elapsedTime = 0.0f;
        //}
    }
}
 