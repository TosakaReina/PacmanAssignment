using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanage : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject GameTimerPanel;
    public GameObject GhostScaredPanel;
    public GameObject RoundStartPrefab;
    public GameObject GhostState;
    public GameObject PacStu;
    public GameObject BGM;
    public GameObject[] PacmanLives;
    
    public Text scoreText;
    public Text gameTimerText;
    public Text ghostScaredText;

    public int WholePelletNum;
    public int eatenPelletNum;
    public int score = 0;
    public float countDownTime = 10;
    private int livesNum = 3;

    public bool ghostScared = false;
    public bool PacmanDead = false;
    

    private void Awake()
    {
        WholePelletNum = GameObject.Find("Pellets").transform.childCount + GameObject.Find("PowerPellets").transform.childCount;
        GhostScaredPanel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameState(false);
        StartCoroutine(RoundStart());

    }

    // Update is called once per frame
    void Update()
    {
        if (ScorePanel.activeInHierarchy)
        {
            scoreText.text = score.ToString();
        }
        if (ghostScared)
        {
            GhostScaredCountDown();
        }
        if (countDownTime <= 0)
        {
            countDownTime = 10;
            ghostScared = false;
            GhostScaredPanel.SetActive(false);
        }
        if (PacmanDead)
        {
            loseLife();
        }
    }

    private void GhostScaredCountDown()
    {
        
        GhostScaredPanel.SetActive(true);
        if (countDownTime >= 0)
        {
            ghostScaredText.text = ((int)countDownTime).ToString();
            countDownTime -= Time.deltaTime;
        }
        
    }

    private void loseLife()
    {
        PacmanLives[livesNum - 1].SetActive(false);
        livesNum--;
        PacmanDead = false;
    }

    IEnumerator RoundStart()
    {
        yield return new WaitForSeconds(4f);
        RoundStartPrefab.SetActive(false);
        gameState(true);
    }

    private void gameState(bool started)
    {
        if (!started)
        {
            PacStu.GetComponent<PacStudentController>().enabled = false;
            GhostState.GetComponent<GhostStateController>().enabled = false;
            BGM.SetActive(false);
        }
        else
        {
            PacStu.GetComponent<PacStudentController>().enabled = true;
            GhostState.GetComponent<GhostStateController>().enabled = true;
            BGM.SetActive(true);
        }
    }
}
