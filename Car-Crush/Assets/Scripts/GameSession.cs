using System;
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
    [SerializeField] float timeBetweenSpawns = 2.3f;
    [SerializeField] float moveSpeed = 3f;
    int livesAdd = 0;


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
        StartCoroutine(SpeedUpGame());
    }

    public float GetMoveSpeed() => moveSpeed;
    public float GetTimeBetweenSpawns() => timeBetweenSpawns;

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        CheckToAddLife(pointsToAdd);
        scoreText.text = score.ToString();
    }

    private void CheckToAddLife(int pointsToAdd)
    {
        livesAdd += pointsToAdd;        
        if (livesAdd%10000 == 0)
        {            
            livesAdd = 0;
            lives++;
            livesText.text = lives.ToString();
        }
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
    private IEnumerator SpeedUpGame()
    {
        yield return new WaitForSeconds(15f);
        moveSpeed += 0.5f;
        if (timeBetweenSpawns > 0.7f)
        {
            timeBetweenSpawns -= 0.3f;
        }
        
        StartCoroutine(SpeedUpGame());
    }
}
