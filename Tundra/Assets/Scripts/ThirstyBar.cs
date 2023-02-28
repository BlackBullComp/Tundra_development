using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ThirstyBar : MonoBehaviour
{
    public Image thirstybar;
    public float thirsty;
    public float minusthirstybarValue;
    public float minustime;
    float percent;
    float maxThirsty = 100f;

    
    void Start()
    {
        thirsty = maxThirsty;
        minusthirstybarValue = 1f;
        minustime = 1f;
    }

    
    void Update()
    {
        percent = thirsty / 100;
       
        thirstybar.fillAmount = percent;
        thirsty -= minusthirstybarValue * Time.deltaTime * minustime;

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            minustime = minustime * 2;
        }
        else
        {
            minustime = 1f;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            minustime = minustime * 2.5f;

        }
        else
        {
            minustime = 1f;


        }


        if (thirsty <= 0)
        {
            thirsty = 0f;
            

        }
    }
}
