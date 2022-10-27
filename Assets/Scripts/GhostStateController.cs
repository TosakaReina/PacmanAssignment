using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostStateController : MonoBehaviour
{

    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;
    public GameObject ghost4;
    public bool scared = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scared)
        {
            ghost1.GetComponent<Animator>().SetBool("scared", true);
            ghost2.GetComponent<Animator>().SetBool("scared", true);
            ghost3.GetComponent<Animator>().SetBool("scared", true);
            ghost4.GetComponent<Animator>().SetBool("scared", true);
        }
    }
}
