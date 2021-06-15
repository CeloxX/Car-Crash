using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{

    [SerializeField] int score = 0;
    [SerializeField] int lives = 5;
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
        livesText.text = lives.ToString();
        StartCoroutine(SpeedUpGame());
    }

    public float GetMoveSpeed() => moveSpeed;
    public float GetTimeBetweenSpawns() => timeBetweenSpawns;
    public int GetScore() => score;

    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        CheckToAddLife(pointsToAdd);
        
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
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("LossScene");
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
