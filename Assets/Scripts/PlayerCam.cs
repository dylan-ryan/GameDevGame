using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCam : MonoBehaviour
{
    public Transform menu;
    public GameObject GrappleGun;

    public float sensX = 100f;
    public float sensY = 100f;

    public Slider senseSlider;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        sensX = PlayerPrefs.GetFloat("currentSensitivity", 100);
        sensY = PlayerPrefs.GetFloat("currentSensitivity", 100);
        senseSlider.value = sensX / 10;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
   void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", sensX);
        PlayerPrefs.SetFloat("currentSensitivity", sensY);
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void AdjustSpeed(float newSpeed)
    {
        sensX = senseSlider.value;
        sensY = senseSlider.value;
    }

    

    public void Pause()
    {
        if (menu.gameObject.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            GrappleGun.gameObject.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            GrappleGun.gameObject.SetActive(true);
        }
    }
}
