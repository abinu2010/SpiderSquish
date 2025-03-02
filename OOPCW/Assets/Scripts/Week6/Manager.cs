using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameOverText;
    public GameObject retryButton;

    private void Start()
    {
        gameOverCanvas.SetActive(true);
        gameOverText.SetActive(false);
        retryButton.SetActive(false);
    }
    public void PlayerDied()
    {
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
        retryButton.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
