using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject postGameObject;
    public GameObject pauseMenu;

    private void Start()
    {
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            postGameObject = GameObject.Find("Post-Game");
            postGameObject.SetActive(false);
            pauseMenu = GameObject.Find("Pause Menu");
            pauseMenu.SetActive(false);
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
}
