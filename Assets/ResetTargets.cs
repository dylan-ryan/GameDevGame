using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTargets : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject player;

    private void PlayerTransform()
    {
        player.transform.position = new Vector3(23f, 0, 21);
        player.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");

        }
        PlayerTransform();
    }
}

