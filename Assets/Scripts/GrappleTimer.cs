using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleTimer : MonoBehaviour
{

    public Animation anim;
    public Component grapplecd;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Grappling>().grapplingCd = 0;
        if()
    }
}
