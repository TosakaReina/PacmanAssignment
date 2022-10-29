using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanage : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject GameTimerPanel;
    public GameObject GhostScaredPanel;
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

    void GhostScaredCountDown()
    {
        
        GhostScaredPanel.SetActive(true);
        if (countDownTime >= 0)
        {
            ghostScaredText.text = ((int)countDownTime).ToString();
            countDownTime -= Time.deltaTime;
        }
        
    }

    void loseLife()
    {
        PacmanLives[livesNum - 1].SetActive(false);
        livesNum--;
        PacmanDead = false;
    }
}
