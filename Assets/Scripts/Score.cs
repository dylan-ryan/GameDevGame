using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Bullet : MonoBehaviour
{
    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();    // give the score manager empty gameobject that tag
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Red") == true)
        {
            // update score
            scoreManager.IncrementScore();
            // handle target, in this example it's just destroyed
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Blue") == true)
        {
            scoreManager.DecrementScore();
            Destroy(other.gameObject);
        }
    }
}