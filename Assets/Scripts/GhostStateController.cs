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
    public bool G1dead = false;
    public bool G2dead = false;
    public bool G3dead = false;
    public bool G4dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ghostScaredToRecovering();
        gottenEaten();
    }

    void ghostScaredToRecovering()
    {
        //scared
        if (scared && !recovering)
        {
            ghost1.GetComponent<Animator>().SetBool("scared", true);
            ghost2.GetComponent<Animator>().SetBool("scared", true);
            ghost3.GetComponent<Animator>().SetBool("scared", true);
            ghost4.GetComponent<Animator>().SetBool("scared", true);
            
        }
        //recovering
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
        //walking
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

    void gottenEaten()
    {
        if (G1dead)
        {
            ghost1.GetComponent<Animator>().SetBool("dead", true);
            ghost1.GetComponent<Animator>().SetBool("recovering", true);
            ghost1.GetComponent<Animator>().SetBool("scared", false);
            Invoke("GhostRespwan", 5.0f);
        }
        if (G2dead)
        {
            ghost2.GetComponent<Animator>().SetBool("dead", true);
            ghost2.GetComponent<Animator>().SetBool("recovering", true);
            ghost2.GetComponent<Animator>().SetBool("scared", false);
            Invoke("GhostRespwan", 5.0f);
        }
        if (G3dead)
        {
            ghost3.GetComponent<Animator>().SetBool("dead", true);
            ghost3.GetComponent<Animator>().SetBool("recovering", true);
            ghost3.GetComponent<Animator>().SetBool("scared", false);
            Invoke("GhostRespwan", 5.0f);
        }
        if (G4dead)
        {
            ghost4.GetComponent<Animator>().SetBool("dead", true);
            ghost4.GetComponent<Animator>().SetBool("recovering", true);
            ghost4.GetComponent<Animator>().SetBool("scared", false);
            Invoke("GhostRespwan", 5.0f);
        }
    }


    private void GhostRespwan()
    {
        if (G1dead)
        {
            ghost1.GetComponent<Animator>().SetBool("dead", false);
            ghost1.GetComponent<Animator>().SetBool("recovering", false);
            ghost1.GetComponent<Animator>().SetBool("scared", false);
            G1dead = false;

        }
        if (G2dead)
        {
            ghost2.GetComponent<Animator>().SetBool("dead", false);
            ghost2.GetComponent<Animator>().SetBool("recovering", false);
            ghost2.GetComponent<Animator>().SetBool("scared", false);
            G2dead = false;
        }
        if (G3dead)
        {
            ghost3.GetComponent<Animator>().SetBool("dead", false);
            ghost3.GetComponent<Animator>().SetBool("recovering", false);
            ghost3.GetComponent<Animator>().SetBool("scared", false);
            G3dead = false;
        }
        if (G4dead)
        {
            ghost4.GetComponent<Animator>().SetBool("dead", false);
            ghost4.GetComponent<Animator>().SetBool("recovering", false);
            ghost4.GetComponent<Animator>().SetBool("scared", false);
            G4dead = false;
        }
    }
    
}


