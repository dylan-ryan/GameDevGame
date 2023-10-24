using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour

{
    // Toggles the time scale between 1 and 0.7
    // whenever the user hits the Fire1 button.
    private float fixedDeltaTime;
    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
            if (Time.timeScale == 1.0f)
                    Time.timeScale = 0.3f;
        }
        if(Input.GetButtonUp("Fire2"))
        { 
            Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 real-time seconds per frame
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }
}