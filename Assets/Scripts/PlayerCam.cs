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

    private float sensX;
    private float sensY;

    public Slider senseSlider;

    public Transform orientation;

    float xRotation;
    float yRotation;

    // Start is called before the first frame update
    void Start()
    {
        sensX = PlayerPrefs.GetFloat("currentSensitivity");
        sensY = PlayerPrefs.GetFloat("currentSensitivity");
        senseSlider.value = sensX;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
   void Update()
    {
        PlayerPrefs.SetFloat("currentSensitivity", sensX);
        PlayerPrefs.SetFloat("currentSensitivity", sensY);
        PlayerPrefs.Save();




        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

       
        if(Time.timeScale == 0.3f)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX * 3f;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY * 3f;
            
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        else
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;
        
            yRotation += mouseX;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
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

    public void OnPlayerClickGun()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GrappleGun.gameObject.SetActive(true);
    }
}
