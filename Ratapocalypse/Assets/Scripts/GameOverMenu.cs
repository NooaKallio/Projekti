using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverCanvas;
    private bool isGameOver = false;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        isGameOver= false;
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            gameOverCanvas.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
