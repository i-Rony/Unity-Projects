using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    bool gameOver = false;
    int score = 0;

    public GameObject gameOverPanel;
    public Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameOver()
    {
        gameOver = true;

        GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().StopSpawning();

        gameOverPanel.SetActive(true);
    }

    public void IncrementScore()
    {
        if (!gameOver)
        {
            score++;
            print(score);

            scoreText.text = score.ToString();

        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }


}
