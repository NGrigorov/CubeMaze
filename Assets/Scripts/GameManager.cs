using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
   
    public  int currScore;
    public  int highScore;
    public  int deathScore;

    public  int CurrLevel = 0;
    public  int CurrLevell = 0;
    public  int unlockedLevel;
    public int tokenCount;

    public UnityEngine.GUISkin guiskin;
    public Color warningColorTime;
    public Color defaultColorTime;
    public float startTime;
    private string currentTime;
    public Rect timerRect;
    private int totalTokensCount;

    public GameObject tokenParent;

    void Update()
    {
        startTime -= Time.deltaTime;
        currentTime = string.Format("{0:0.0}",startTime);
        print(currentTime);
        if(startTime <= 0)
        {
            startTime = 0;
            SceneManager.LoadScene(0);
        }
    }


    void Start()
    {
        totalTokensCount = tokenParent.transform.childCount;

        //DontDestroyOnLoad(gameObject);
        if(PlayerPrefs.GetInt("Level Completed") > 0)
            CurrLevell = PlayerPrefs.GetInt("Level Completed");
        else
            CurrLevell = 0;

        if (PlayerPrefs.GetInt("Score") > 0)
            currScore = PlayerPrefs.GetInt("Score");
        else
            currScore = 0;

        if (PlayerPrefs.GetInt("Deaths") > 0)
            deathScore = PlayerPrefs.GetInt("Deaths");
        else
            deathScore = 0;

        if (PlayerPrefs.GetInt("HighScore") > 0)
            highScore = PlayerPrefs.GetInt("HighScore");
        else
            highScore = 0;

    }
    public  void CompleteLevel()
    {
        //Application.LoadLevel(CurrLevel);
        CurrLevel = SceneManager.GetActiveScene().buildIndex;
        if (CurrLevel < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(CurrLevel + 1);
            CurrLevell++;
            PlayerPrefs.SetInt("Level Completed", CurrLevell);
            PlayerPrefs.SetInt("Score", currScore);
            PlayerPrefs.SetInt("Deaths", deathScore);
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        else
            print("You won!");
    }
    void OnGUI()
    {
        UnityEngine.GUI.skin = guiskin;
        if(startTime <= 5)
        {
            guiskin.GetStyle("Timer").normal.textColor = warningColorTime;
        }
        else
        {
            guiskin.GetStyle("Timer").normal.textColor = defaultColorTime;
        }
        UnityEngine.GUI.Label(timerRect, currentTime,guiskin.GetStyle("Timer"));
        UnityEngine.GUI.Label(new Rect(45,100,200,200), tokenCount.ToString() + " / " + totalTokensCount.ToString());
        UnityEngine.GUI.Label(new Rect(20, 10, Screen.width, Screen.height), "Current Score:  " + PlayerPrefs.GetInt("Score") + "  " +
                    "HighScore:  " + PlayerPrefs.GetInt("HighScore") + "  " +
                    "Deaths:   " + PlayerPrefs.GetInt("Deaths") + "  " +
                     "Current Level:  " + CurrLevell);
    }
    public void AddToken()
    {
        tokenCount += 1;
    }
}
