using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacStudentController : MonoBehaviour
{
    [SerializeField]
    private GameObject item;
    private Tweener tweener;
    private KeyCode lastInput;
    public Animator PacAnimator;
    public AudioSource footstepSource;
    public AudioClip[] footStepClips;

    public ParticleSystem wallCollisionParticle;
    private ParticleSystem CloneParticle;

    public GameObject cherrySpwaner;
    public GameObject ghostStateController;
    public GameObject BackgourndMusic;

    private float elapsedTime;
    private Vector2 destination;
    private Vector2 teleportLeft = new Vector2(-14, 0);
    private Vector2 teleportRight = new Vector2(13, 0);
    private bool scaredBGMplayed = false;
    private bool pacDead = false;
    private bool powerPacman = false;

    // Start is called before the first frame update
    void Start()
    {
        tweener = GetComponent<Tweener>();
        destination = item.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pacManMovement();
        PacmanTP();
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(item.transform.position);
        }
        StopScaredBGM();
        
    }

    private void pacManMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            lastInput = KeyCode.W;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            lastInput = KeyCode.S;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            lastInput = KeyCode.A;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            lastInput = KeyCode.D;
        }

        //make sure pacStudent move grid by grid
        if ((Vector2)item.transform.position == destination && lastInput != KeyCode.None)
        {

            if (lastInput == KeyCode.W)
            {
                destination += Vector2.up;
                PacAnimator.SetBool("Up", true);
                PacAnimator.SetBool("Left", false);

            }
            else if (lastInput == KeyCode.S)
            {
                destination += Vector2.down;
                PacAnimator.SetBool("Up", false);
                PacAnimator.SetBool("Left", true);
            }
            else if (lastInput == KeyCode.A)
            {
                destination += Vector2.left;
                PacAnimator.SetBool("Up", true);
                PacAnimator.SetBool("Left", true);
            }
            else if (lastInput == KeyCode.D)
            {
                destination += Vector2.right;
                PacAnimator.SetBool("Up", false);
                PacAnimator.SetBool("Left", false);
            }

            tweener.AddTween(item.transform, item.transform.position, destination, 0.25f);
            footstepSource.clip = footStepClips[1];
            footstepSource.volume = 0.5f;
            footstepSource.Play();
        }

        if (tweener.activeTween == null)
        {
            if (pacDead)
            {
                PacAnimator.speed = 1;
            }
            else if(!pacDead)
            {
                PacAnimator.speed = 0;
            }
        }
        else
        {
            PacAnimator.speed = 1;
        }
    }

    private void PacmanTP()
    {
        if((Vector2)item.transform.position == teleportLeft)
        {
            if(lastInput == KeyCode.A)
            {
                tweener.activeTween = null;
                item.transform.position = (Vector3)teleportRight;
                destination = (Vector2)item.transform.position + Vector2.left;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.25f);
            }
        }

        if ((Vector2)item.transform.position == teleportRight)
        {
            if (lastInput == KeyCode.D)
            {
                tweener.activeTween = null;
                item.transform.position = (Vector3)teleportLeft;
                destination = (Vector2)item.transform.position + Vector2.right;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.25f);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision with Wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            //prevent movement
            if (lastInput == KeyCode.W)
            {
                destination += Vector2.down;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.001f);
                lastInput = KeyCode.None;
            }
            else if (lastInput == KeyCode.S)
            {
                destination += Vector2.up;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.001f);
                lastInput = KeyCode.None;
            }
            else if (lastInput == KeyCode.A)
            {
                destination += Vector2.right;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.001f);
                lastInput = KeyCode.None;
            }
            else if (lastInput == KeyCode.D)
            {
                destination += Vector2.left;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.001f);
                lastInput = KeyCode.None;
            }

            //collision particle effect
            CloneParticle = Instantiate(wallCollisionParticle, collision.ClosestPoint(item.transform.position), Quaternion.identity);
            CloneParticle.Play();
            


            //footstep sound
            footstepSource.clip = footStepClips[2];
            footstepSource.volume = 0.5f;
            footstepSource.Play();
        }else if (collision.gameObject.CompareTag("Pellet"))
        {
            Destroy(collision.gameObject);
            footstepSource.clip = footStepClips[0];
            footstepSource.volume = 0.2f;
            footstepSource.Play();
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            Destroy(cherrySpwaner.GetComponent<CherryController>().CloneCherry);
            cherrySpwaner.GetComponent<CherryController>().destroyed = true;

        }else if (collision.gameObject.CompareTag("PowerPellet"))
        {
            powerPacman = true;
            Destroy(collision.gameObject);
            footstepSource.clip = footStepClips[0];
            footstepSource.volume = 0.2f;
            footstepSource.Play();
            ghostStateController.GetComponent<GhostStateController>().scared = true;
            BackgourndMusic.GetComponent<AudioSource>().clip = BackgourndMusic.GetComponent<InTurnAudioClip>().audioClips[1];
            BackgourndMusic.GetComponent<AudioSource>().Play();
            scaredBGMplayed = true;
        }else if (collision.gameObject.CompareTag("Ghost"))
        {
            //ghost walking state
            if (!powerPacman)
            {
                PacAnimator.SetBool("die", true);
                pacDead = true;
                tweener.activeTween = null;
                Invoke("respawnPac", 0.85f);
            }
            //ghost Scared or Recovering state
            else
            {
                if (collision.gameObject == ghostStateController.GetComponent<GhostStateController>().ghost1)
                {
                    ghostStateController.GetComponent<GhostStateController>().G1dead = true;
                }else if (collision.gameObject == ghostStateController.GetComponent<GhostStateController>().ghost2)
                {
                    ghostStateController.GetComponent<GhostStateController>().G2dead = true;
                }
                else if (collision.gameObject == ghostStateController.GetComponent<GhostStateController>().ghost3)
                {
                    ghostStateController.GetComponent<GhostStateController>().G3dead = true;
                }
                else if (collision.gameObject == ghostStateController.GetComponent<GhostStateController>().ghost4)
                {
                    ghostStateController.GetComponent<GhostStateController>().G4dead = true;
                }
            }
        }
    }

    void StopScaredBGM()
    {
        if (scaredBGMplayed)
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime >= 7.0f && elapsedTime < 10.0f)
            {
                ghostStateController.GetComponent<GhostStateController>().recovering = true;
                ghostStateController.GetComponent<GhostStateController>().scared = false;
            }

            if(elapsedTime >= 10.0f)
            {
                BackgourndMusic.GetComponent<AudioSource>().clip = BackgourndMusic.GetComponent<InTurnAudioClip>().audioClips[0];
                BackgourndMusic.GetComponent<AudioSource>().Play();
                scaredBGMplayed = false;
                elapsedTime = 0.0f;
                ghostStateController.GetComponent<GhostStateController>().recovering = false;
                powerPacman = false;
            }
        }
    }

    void respawnPac()
    {
        item.transform.position = new Vector3(-13.0f, 13.0f, 0.0f);
        destination = item.transform.position;
        pacDead = false;
        PacAnimator.SetBool("die", false);
        PacAnimator.SetBool("Up", false);
        PacAnimator.SetBool("Left", false);
        lastInput = KeyCode.None;
    }



}
