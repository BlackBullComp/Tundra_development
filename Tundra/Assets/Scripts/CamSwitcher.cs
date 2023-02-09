using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    public Camera ThirdPersonCam;
    public Camera FirstPersonCam;
    bool switchcams;
    // Start is called before the first frame update
    void Start()
    {
        FirstPersonCam.gameObject.SetActive(false); 
        ThirdPersonCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.C))
        {
            switchcams = !switchcams;
        }

        if (switchcams)
        {

            FirstPersonCam.gameObject.SetActive(true);
            ThirdPersonCam.gameObject.SetActive(true);
        }
        else
        {

            FirstPersonCam.gameObject.SetActive(false);
            ThirdPersonCam.gameObject.SetActive(true);
        }



    }
}
