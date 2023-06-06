using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject HowToPlay;
    public GameObject Credits;

    public AudioSource gameAudio;
    public AudioClip Clip;
    public GameObject MusicOnButton;
    public GameObject MusicOffButton;

    public Animator settingAnimator;
    public GameObject FadePanel;
    void Start()
    {
        MainMenu.SetActive(true);
        Settings.SetActive(false);
        HowToPlay.SetActive(false);
        Credits.SetActive(false);
        MusicOffButton.SetActive(true);
        gameAudio.Play();
        FadeIn();
    }

    public void SettingsButtonClicked()
    {
        
        MainMenu.SetActive(false);
        Settings.SetActive(true);
        settingAnimator.SetTrigger("SlideDown");
        PlayButtonSound();
        
    }
    public void HowToPlayButtonClicked() 
    {
        MainMenu.SetActive(false);
        HowToPlay.SetActive(true);
        PlayButtonSound();
    }
    public void CreditsButtonClicked()
    {
        MainMenu.SetActive(false);
        Credits.SetActive(true) ;
        PlayButtonSound();

    }
    public void SettingBackButtonClicked()
    {
        MainMenu.SetActive(true);
        settingAnimator.SetTrigger("SlideUP");
        
        Invoke("DisableSettingPanel", 1f);
       // Credits.SetActive(true);
       // HowToPlay.SetActive(true);
    }
    public void DisableSettingPanel()
    {
        Settings.SetActive(false);
    }

    public void BackButtonClicked()
    {
        Settings.SetActive(false);
        MainMenu.SetActive(true);
        Credits.SetActive(false);
        HowToPlay.SetActive(false);
    }


    public void PlayButtonClicked()
    {
        
        SceneManager.LoadScene("GamePlayScene");
        FadeIn();

        //OR
        //SceneManager.LoadScene(1);
    }

    public void MusicOnButtonClicked()
    {
        gameAudio.Play();
        MusicOnButton.SetActive(false) ;
        MusicOffButton.SetActive(true) ;
    }

    public void MusicOffButtonClicked()
    {
        gameAudio.Stop();
        MusicOnButton.SetActive(true);
        MusicOffButton.SetActive(false);
    }

    public void PlayButtonSound()
    {
        gameAudio.PlayOneShot(Clip);

    }

    private void FadeIn()
    {
        FadePanel.GetComponent < Animator >().SetTrigger("Fade-In");
    }
    private void FadeOut()
    {
        FadePanel.GetComponent<Animator>().SetTrigger("Fade-Out");
    }


    }
