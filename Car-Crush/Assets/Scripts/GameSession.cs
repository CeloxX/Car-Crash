using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{

    [SerializeField] int score = 0;
    [SerializeField] int lives = 5;
    [SerializeField] Text scoreText;
    [SerializeField] Text livesText;


    public static GameSession Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
    }

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    public void SubtractLife()
    {
        lives--;
        livesText.text = lives.ToString();
        if (lives <= 0)
        {
            StartCoroutine(LoadLossScreen());
        }
    }

    private IEnumerator LoadLossScreen()
    {
        yield return new WaitForSeconds(1);
    }
}
