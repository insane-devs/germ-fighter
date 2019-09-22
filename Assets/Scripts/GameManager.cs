using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject postGameObject;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public GameObject infoMenu;
    public GameObject playMenu;
    public GameObject networkManager;
    public GameObject multiMenu;

    public Slider slider;

    private int muted;

    void Start()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            postGameObject.SetActive(false);
            pauseMenu.SetActive(false);
        } else
        {
            settingsMenu.SetActive(false);
            infoMenu.SetActive(false);
            playMenu.SetActive(false);
            networkManager.SetActive(false);
            multiMenu.SetActive(false);
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("mute", 0) == 0) GameObject.FindWithTag("Music").GetComponent<AudioSource>().UnPause();
        else GameObject.FindWithTag("Music").GetComponent<AudioSource>().Pause();
        if (SceneManager.GetActiveScene().name == "GameScene" && !GameObject.FindWithTag("Enemy") && !GameObject.FindWithTag("Enemy Boss"))
        {
            FindObjectOfType<Timer>().EndWave();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0) return;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        if (Time.timeScale == 1) return;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void ToggleSounds()
    {
        muted = PlayerPrefs.GetInt("mute", 0);
        if (muted == 1) PlayerPrefs.SetInt("mute", 0);
        else PlayerPrefs.SetInt("mute", 1);
        PlayerPrefs.Save();
    }

    public void ToggleSettings()
    {
        settingsMenu.SetActive(!settingsMenu.activeSelf);
        slider.value = PlayerPrefs.GetFloat("volume", slider.value);
    }

    public void ToggleInfo()
    {
        infoMenu.SetActive(!infoMenu.activeSelf);
    }

    public void TogglePlay()
    {
        playMenu.SetActive(!playMenu.activeSelf);
    }

    public void ToggleMulti()
    {
        multiMenu.SetActive(!multiMenu.activeSelf);
        playMenu.SetActive(!playMenu.activeSelf);
        networkManager.SetActive(true);
    }

    public void GoHome()
    {
        settingsMenu.SetActive(false);
        infoMenu.SetActive(false);
        playMenu.SetActive(false);
        networkManager.SetActive(false);
        multiMenu.SetActive(false);
    }
}
