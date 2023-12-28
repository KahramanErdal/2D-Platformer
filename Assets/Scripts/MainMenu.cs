using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject inmainMenu;
    public GameObject settingsMenu;
    public GameObject pauseMenu;
    private bool _isPlay;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    
}
