using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Score : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }

        if (other.gameObject.CompareTag("Blue"))
        {
            other.gameObject.SetActive(false);
            count = count - 1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
    }
}
