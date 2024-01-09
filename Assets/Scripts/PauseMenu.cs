using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public AudioMixer audioMixer;
    public GameObject pauseMenuButtons;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void ResumeButton()
    {
        pauseMenuUI.SetActive(false);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void BackmenuButton() 
    { 
        settingsMenuUI.SetActive(false);
        pauseMenuButtons.SetActive(true);
    }

    public void SettingsButton()
    {
        settingsMenuUI.SetActive(true);
        pauseMenuButtons.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
