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
        pacManMovement();
        
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
            footstepSource.clip = footStepClips[0];
            footstepSource.volume = 0.8f;
            footstepSource.Play();
        }

        if (tweener.activeTween == null)
        {
            PacAnimator.speed = 0;
        }
        else
        {
            PacAnimator.speed = 1;
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
                tweener.AddTween(item.transform, item.transform.position, destination, 0.05f);
                lastInput = KeyCode.None;
            }
            else if (lastInput == KeyCode.S)
            {
                destination += Vector2.up;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.05f);
                lastInput = KeyCode.None;
            }
            else if (lastInput == KeyCode.A)
            {
                destination += Vector2.right;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.05f);
                lastInput = KeyCode.None;
            }
            else if (lastInput == KeyCode.D)
            {
                destination += Vector2.left;
                tweener.activeTween = null;
                tweener.AddTween(item.transform, item.transform.position, destination, 0.05f);
                lastInput = KeyCode.None;
            }

            //collision particle effect
            CloneParticle = Instantiate(wallCollisionParticle, collision.ClosestPoint(item.transform.position), Quaternion.identity);
            CloneParticle.Play();
            


            //footstep sound
            footstepSource.clip = footStepClips[2];
            footstepSource.volume = 0.5f;
            footstepSource.Play();
        }
    }

}
