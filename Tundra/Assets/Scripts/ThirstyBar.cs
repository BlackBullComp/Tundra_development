using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ThirstyBar : MonoBehaviour
{
    public Slider thirstybar;
    public float thirsty;
    float maxThirsty = 100f;

    
    void Start()
    {
        thirsty = maxThirsty;
    }

    
    void Update()
    {
        Debug.Log(thirsty);
       thirstybar.value = thirsty;
        thirsty= 1f * Time.deltaTime;


        if (Input.GetKey(KeyCode.W))
        { thirsty -= 2f * Time.deltaTime; }

        if (Input.GetKey(KeyCode.A))
        { thirsty -= 2f * Time.deltaTime; }

        if (Input.GetKey(KeyCode.S))
        { thirsty -= 2f * Time.deltaTime; }

        if (Input.GetKey(KeyCode.D))
        { thirsty -= 2f * Time.deltaTime; }


        if(Input.GetKeyDown(KeyCode.Space))
        { thirsty -= 2.5f; }

        if (Input.GetKey(KeyCode.LeftShift))
        { thirsty -= 3f * Time.deltaTime; }

        if(thirsty <= 0)
        {
            thirsty = 0f;
        }
    }
}
