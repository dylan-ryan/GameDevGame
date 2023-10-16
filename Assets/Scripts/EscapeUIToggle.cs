using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeUIToggle : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Bullets;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {            
            Player.SetActive(false);
            Bullets.SetActive(false);
            PauseMenu.SetActive(true); 
            Time.timeScale = 0f;
        }

    }
}
