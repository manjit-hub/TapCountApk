using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Text = TMPro.TextMeshProUGUI;
using System.Threading;

public class GamePlayUI : MonoBehaviour
{
    public GameObject GamePlayPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject WonPanel;

    public GameManager gameManager;
    public GameObject HighScoreText;

    public GameObject TargetText;
    int aTargetText;

    void Start()
    {
        GamePlayPanel.SetActive(true);
        gameManager.TimerText.SetActive(true);
    }

    
    public void UpdateTapCountText()
    {
        gameManager.TapCountText.GetComponent<Text>().text = gameManager.TapCount.ToString();
    }
    public void BackButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButtonClicked()
    {
        GamePlayPanel.SetActive(false);
        PausePanel.SetActive(true);
        gameManager.isPause = true;
    }

    public void ResumeButtonClicked()
    {
        gameManager.isPause = false;
        PausePanel.SetActive(false);
        GamePlayPanel.SetActive(true) ;

    }

    public void RestartButtonClicked() 
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {
       Environment.Exit(0);
    }

    public void TimerText()
    {
        gameManager.TimerText.GetComponent<Text>().text=gameManager.Timer.ToString("0");
    }

    public void EndOfGame()
    {
        
        GamePlayPanel.SetActive(false);
        if (gameManager.HasWon==false)
        {
            GameOverPanel.SetActive(true);
        }
        else
        {
            WonPanel.SetActive(true);
        }
    }

    public void HighScoreTextDisplay()
    {
        HighScoreText.GetComponent<Text>().text = gameManager.HighScore.ToString();
    }

    public void ReplayButtonClicked()
    {
        GameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void MainMenuButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        aTargetText = gameManager.GetTapCountTarget(gameManager.GetLevelNum());
        Debug.Log(aTargetText);
        gameManager.SaveLevelNum();
        Debug.Log("TapCount Target is " + aTargetText   );
        UpdateTargetText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateTargetText()
    {
        TargetText.GetComponent<Text>().text = aTargetText.ToString();
        Debug.Log("UpdateTargetText Working!!");
    }
}
