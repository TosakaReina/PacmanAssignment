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
    public bool recovering = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ghostScaredToRecovering();
    }

    void ghostScaredToRecovering()
    {
        if (scared && !recovering)
        {
            ghost1.GetComponent<Animator>().SetBool("scared", true);
            ghost2.GetComponent<Animator>().SetBool("scared", true);
            ghost3.GetComponent<Animator>().SetBool("scared", true);
            ghost4.GetComponent<Animator>().SetBool("scared", true);
        }
        else if (recovering && !scared)
        {
            ghost1.GetComponent<Animator>().SetBool("recovering", true);
            ghost2.GetComponent<Animator>().SetBool("recovering", true);
            ghost3.GetComponent<Animator>().SetBool("recovering", true);
            ghost4.GetComponent<Animator>().SetBool("recovering", true);
            ghost1.GetComponent<Animator>().SetBool("scared", false);
            ghost2.GetComponent<Animator>().SetBool("scared", false);
            ghost3.GetComponent<Animator>().SetBool("scared", false);
            ghost4.GetComponent<Animator>().SetBool("scared", false);
        }
        else if (!recovering && !scared)
        {
            ghost1.GetComponent<Animator>().SetBool("recovering", false);
            ghost2.GetComponent<Animator>().SetBool("recovering", false);
            ghost3.GetComponent<Animator>().SetBool("recovering", false);
            ghost4.GetComponent<Animator>().SetBool("recovering", false);
            ghost1.GetComponent<Animator>().SetBool("scared", false);
            ghost2.GetComponent<Animator>().SetBool("scared", false);
            ghost3.GetComponent<Animator>().SetBool("scared", false);
            ghost4.GetComponent<Animator>().SetBool("scared", false);
        }
    }
}
