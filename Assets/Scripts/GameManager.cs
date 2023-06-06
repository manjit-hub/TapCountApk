using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Text = TMPro.TextMeshProUGUI;

public class GameManager : MonoBehaviour
{
    public int TapCount;
    public GameObject TapCountText;
    public GamePlayUI gameplayUI;
    public bool TimerHasEnd = false;
    public float DefaultTimerValue;
    public float Timer;
    public GameObject TimerText;
    public bool isPause = false;

    public float TargetCount;
    public bool HasWon = false;
    public int HighScore;
    public AudioSource gameplayAudio;
    public AudioClip ClickClip1;
    public AudioClip ClickClip2;
    public AudioClip ClickClip3;

    int LevelNum=1;
    int BaseLevelMultiplier=10;

    void Start()
    {
        if(PlayerPrefs.HasKey("LevelNum"))
        {
            LevelNum = PlayerPrefs.GetInt("LevelNum");
        }
        //OR 
        // LevelNum = PlayerPrefs.GetInt("LevelNum",1); here 1 is the default value;
        // it will return 1 when LevelNum is not present in PlayerPref

        TargetCount = GetTapCountTarget(LevelNum);
        Debug.Log("Target Count is "+ TargetCount);
        Timer = DefaultTimerValue;
        GetHighScore();
        gameplayUI.HighScoreTextDisplay();
    }
    void Update()
    {
        if (TimerHasEnd == false)
        {
            if(isPause == false) 
            {
                Timer -= 1 * Time.deltaTime;
            }
            
            gameplayUI.TimerText();
            if (Timer <= 0)
            {
                TimerHasEnd = true;
                Timer = 0;

                if (TapCount >= TargetCount)
                {
                    HasWon = true;

                }
                else
                {
                    HasWon = false;
                }
                gameplayUI.HighScoreTextDisplay();
                gameplayUI.EndOfGame();
                Debug.Log("Player has Won: " + HasWon);

                if (TapCount >= HighScore)
                {
                    HighScore = TapCount;
                    SaveHighScore();
                    gameplayUI.HighScoreTextDisplay();
                    Debug.Log("High Score is: " + HighScore);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                TapCount++;
                ClickSound();
                gameplayUI.UpdateTapCountText();
            }
        }

    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", HighScore);
        Debug.Log("High Score Saved!");
    }

    public void GetHighScore()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    public void ClickSound()
    {
        if(TapCount%2 == 0 || TapCount % 6 == 0) 
        {
            gameplayAudio.PlayOneShot(ClickClip1);
        }
       
        else if(TapCount%3 == 0 || TapCount%5==0 || TapCount % 7 == 0)
        {
            gameplayAudio.PlayOneShot(ClickClip2);
        }
        else
        {
            gameplayAudio.PlayOneShot(ClickClip3);
        }
    }

    public int GetTapCountTarget(int LevelNum)
    {
       return LevelNum * BaseLevelMultiplier;
    }
   /* public int LevelNumValue()
    {
        return LevelNum;
    }*/
    public int GetLevelNum() 
    {
        LevelNum++;
        return LevelNum;
    }

    public void SaveLevelNum()
    {
        PlayerPrefs.SetInt("LevelNum", LevelNum);
        Debug.Log("Old LevelNum saved !!");
    }
}


