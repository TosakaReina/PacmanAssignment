using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDmanage : MonoBehaviour
{
    public GameObject ScorePanel;
    public GameObject GameTimerPanel;
    public GameObject GhostScaredPanel;
    public GameObject RoundStartPrefab;
    public GameObject GameOverText;
    public GameObject GhostState;
    public GameObject PacStu;
    public GameObject BGM;
    public GameObject[] PacmanLives;
    
    public Text scoreText;
    public Text gameTimerText;
    public Text ghostScaredText;

    public int WholePelletNum;
    public int eatenPelletNum;
    public int score;
    public float countDownTime = 10;
    private int livesNum = 3;
    private float Gametime = 0;
    private float gameOverTime = 3.0f;

    public bool ghostScared = false;
    public bool PacmanDead = false;
    private bool gameStarted = false;
    private bool gameOver = false;

    

    private void Awake()
    {
        WholePelletNum = GameObject.Find("Pellets").transform.childCount + GameObject.Find("PowerPellets").transform.childCount;
        GhostScaredPanel.SetActive(false);
        GameOverText.SetActive(false);
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
        if (gameStarted && GameTimerPanel.activeInHierarchy)
        {
            GameTimer();
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
        if(WholePelletNum - eatenPelletNum == 0 || livesNum == 0)
        {
            GameOver();
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
            PacStu.GetComponent<PacStudentController>().PacAnimator.speed = 0;
            PacStu.GetComponent<PacStudentController>().enabled = false;
            GhostState.GetComponent<GhostStateController>().enabled = false;
            BGM.SetActive(false);
        }
        else
        {
            PacStu.GetComponent<PacStudentController>().enabled = true;
            GhostState.GetComponent<GhostStateController>().enabled = true;
            BGM.SetActive(true);
            gameStarted = true;
        }
    }

    private void GameTimer()
    {
        if (!gameOver)
        {
            Gametime += Time.deltaTime;
        }
        int min = (int)Gametime / 60;
        int sec = (int)Gametime % 60;
        float msec = Gametime * 100 % 100;
        gameTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
        
        
    }

    private void GameOver()
    {
        GameOverText.SetActive(true);
        PacStu.GetComponent<PacStudentController>().PacAnimator.speed = 0;
        PacStu.GetComponent<PacStudentController>().enabled = false;
        GhostState.GetComponent<GhostStateController>().enabled = false;
        BGM.SetActive(false);
        gameOver = true;

        //compare and save highest score
        int previousScoreRecord = PlayerPrefs.GetInt("ScoreRecord", 0);
        if(score > previousScoreRecord)
        {
            PlayerPrefs.SetInt("ScoreRecord", score);
            PlayerPrefs.SetFloat("TimeRecord", Gametime);
        }else if(score == previousScoreRecord)
        {
            float previousTimeRecord = PlayerPrefs.GetFloat("TimeRecord", 1000);
            if (Gametime < previousTimeRecord)
            {
                PlayerPrefs.SetFloat("TimeRecord", Gametime);
            }
        }

        //remain 3s
        gameOverTime -= Time.deltaTime;
        if(gameOverTime <= 0)
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        }

    }
}
