using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text ScoreRecord;
    public Text TimeRecord;

    private Button quitButton;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        int SRecord = PlayerPrefs.GetInt("ScoreRecord", 0);
        ScoreRecord.text = SRecord.ToString();

        float TRecord = PlayerPrefs.GetFloat("TimeRecord", 1000);
        int min = (int)TRecord / 60;
        int sec = (int)TRecord % 60;
        float msec = TRecord * 100 % 100;
        TimeRecord.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            if (GameObject.FindGameObjectWithTag("QuitButton"))
            {
                quitButton = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();

                quitButton.onClick.AddListener(QuitGame);
            }
        }
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
