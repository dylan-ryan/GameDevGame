using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score;

    public void IncrementScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void DecrementScore()
    {
        score--;
        scoreText.text = score.ToString();
    }
}