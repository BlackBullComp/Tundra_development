using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delayedarmmotion : MonoBehaviour
{

    public GameObject Camera;
    // Stt is called before the first frame update
    private void LateUpdate()
    {

        transform.rotation = Camera.transform.rotation;
    }
    

    // Update is called once per frame


 
}
