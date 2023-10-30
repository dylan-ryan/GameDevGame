using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using TMPro;

public class TimeScore : MonoBehaviour
{
    public float timerScore;
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
            timerScore += Time.deltaTime;
            timerText.text = (timerScore).ToString("0");
    }
}
