using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hungrybarscript : MonoBehaviour
{
    
    public Slider HungerSlider;

  

    public float Hunger;
    float maxHunger = 100f;
    void Start()
    {
        Hunger = maxHunger;
    }

    
    void Update()
    {
        Debug.Log(Hunger);
        //de�erin oyun �c�nde deg�seceg� �c�n buraya yaz�yoruz.
        HungerSlider.value = Hunger;
        Hunger -= 1f* Time.deltaTime;

        //a�l�k bar�n� azaltt�k
        if(Input.GetKey(KeyCode.W))
            { Hunger -= 2f * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A))
        { Hunger -= 2f * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S))
        { Hunger -= 2f * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D))
        { Hunger -= 2f * Time.deltaTime; }

        if (Input.GetKey(KeyCode.LeftShift))
        { Hunger -= 3f * Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.Space))
        { Hunger -= 2.5f; }

    }
}
