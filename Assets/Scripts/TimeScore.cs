using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.SocialPlatforms.Impl;

public class TimeScore : MonoBehaviour
{
    public float timerScore = 0.0f;
    public int timerSeconds;
    public TextMeshProUGUI timerText;
    public int endTimeScore;
    public TextMeshProUGUI fakeTimerText;

    public int timehighscore;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        fakeTimerText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        timehighscore = PlayerPrefs.GetInt("", timehighscore);
        text.text = timehighscore.ToString();
    }

    private void Update()
    {
        if (timerSeconds > timehighscore)
        {
            timehighscore = timerSeconds;
            text.text = "" + timerSeconds;

            PlayerPrefs.SetInt("highscore", timehighscore);
        }
    }

    void Timer()
    {
        timerScore += Time.deltaTime;
        timerSeconds = (int)(timerScore % 60);
        timerText.text = (timerSeconds).ToString("0");
    }
    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {
        //if (other.CompareTag("Blue") == true)
        //{
        //    timerText.text = timerText.text + 1;
        //    other.gameObject.SetActive(false);
        //}

        if (other.gameObject.CompareTag("Player"))
        {
            timerSeconds -= timerSeconds;
            Timer();

            fakeTimerText.gameObject.SetActive(false);
            timerText.gameObject.SetActive (true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (timerSeconds > timehighscore)
            {
                timehighscore = timerSeconds;
                text.text = "" + timerSeconds;

                PlayerPrefs.SetInt("highscore", timehighscore);
            }
            endTimeScore = timerSeconds;
            timerText.text = (endTimeScore).ToString("0");
        }
    }

    //public void ShootBlue()
    //{
    //    timerSeconds += 1000;
        
    //}
}
