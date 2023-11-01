using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using TMPro;
using Unity.VisualScripting;

public class TimeScore : MonoBehaviour
{
    public float timerScore = 0.0f;
    public int timerSeconds;
    public TextMeshProUGUI timerText;
    public int endTimeScore;
    public TextMeshProUGUI fakeTimerText;
    // Start is called before the first frame update
    void Start()
    {
        fakeTimerText.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
    }

    private void Update()
    {
        
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
            endTimeScore = timerSeconds;
            timerText.text = (endTimeScore).ToString("0");
        }
    }
}
