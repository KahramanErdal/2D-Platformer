using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingsMenu()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);        
    }
    public void BackSettingsButton()
    {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
