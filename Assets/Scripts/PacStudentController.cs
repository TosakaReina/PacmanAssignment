using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private Tweener tweener;

    private float elapsedTime;
    private Vector2 destination;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        destination = item.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)item.transform.position == destination)
        {
            if (Input.GetKey(KeyCode.W))
            {
                destination += Vector2.up;
            }else if (Input.GetKey(KeyCode.S))
            {
                destination += Vector2.down;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                destination += Vector2.left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                destination += Vector2.right;
            }

            tweener.AddTween(item.transform, item.transform.position, destination, 0.25f);
        }
    }

    

}
