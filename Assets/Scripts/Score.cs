using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Bullet : MonoBehaviour
{
    private ScoreManager scoreManager;
    //private TimeScore timeScore;

    private void Start()
    {
        //timeScore = GameObject.FindWithTag("TimeScore").GetComponent<TimeScore>();
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();    // give the score manager empty gameobject that tag
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red") == true)
        {
            // update score
            scoreManager.IncrementScore();
            // handle target, in this example it's just destroyed
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Blue") == true)
        {
            scoreManager.DecrementScore();
            other.gameObject.SetActive(false);
        }

        //if (other.CompareTag("Blue") == true)
        //{
        //    timeScore.ShootBlue();
        //    other.gameObject.SetActive(false);
        //}
    }
}