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
    public GameObject levelSelect;
    public void PlayGame()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
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
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    public void LevelOneButton()
    {
        SceneManager.LoadSceneAsync("Level1");
        Time.timeScale = 1f;
    }
    public void LevelTwoButton()
    {
        SceneManager.LoadSceneAsync("Level2");
        Time.timeScale = 1f;
    }
}
