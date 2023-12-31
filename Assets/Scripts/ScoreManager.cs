using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public int score;

    private ScoreManager scoreManager;
    public int highscore;
    public TextMeshProUGUI text;

    public GameObject trigger;
    // Start is called before the first frame update
    void Start()
    {

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        text.text = highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            text.text = "" + score;

            PlayerPrefs.SetInt("highscore", highscore);
        }
        
    }
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