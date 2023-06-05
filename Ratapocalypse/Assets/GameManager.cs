using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float elapsedTime = 0f;  // Elapsed time in seconds

    public GameObject timerTextObject;
    public GameObject gameOverMenu;

    private Text timerText;
    private bool isGameOver = false;

    private List<GameObject> bullets = new List<GameObject>();
    private List<GameObject> enemies = new List<GameObject>();

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timerText = timerTextObject.GetComponent<Text>();
    }

    private void Update()
    {
        if (!isGameOver)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerText();
        }
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        string timerString = string.Format("{0}:{1:00}", minutes, seconds);
        timerText.text = timerString;
    }

    public void AddBullet(GameObject bullet)
    {
        bullets.Add(bullet);
    }

    public void RemoveBullet(GameObject bullet)
    {
        bullets.Remove(bullet);
    }

    public void AddEnemy(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverMenu.SetActive(true);

        // Stop spawning enemies
        StopAllCoroutines();

        // Disable bullet movement
        foreach (GameObject bullet in bullets)
        {
            if (bullet != null)
            {
                Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
                if (bulletRb != null)
                {
                    bulletRb.velocity = Vector2.zero;
                }
            }
        }

        // Disable enemy movement
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
                if (enemyRb != null)
                {
                    enemyRb.velocity = Vector2.zero;
                }
            }
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
