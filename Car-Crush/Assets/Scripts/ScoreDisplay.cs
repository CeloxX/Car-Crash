using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;   

    int score;
    private void Start()
    {
        scoreText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        score = GameSession.Instance.GetScore();
        scoreText.text = score.ToString();        
    }
}
