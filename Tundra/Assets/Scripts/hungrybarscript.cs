using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hungrybarscript : MonoBehaviour
{
    
    public Slider HungerSlider;


    public GameObject Player;

    public float Hunger;
    float maxHunger = 100f;
    void Start()
    {
        Hunger = maxHunger;
    }

    
    void Update()
    {
        
        //deðerin oyun ýcýnde degýsecegý ýcýn buraya yazýyoruz.
        HungerSlider.value = Hunger;
        Hunger -= 1f* Time.deltaTime;

        //açlýk barýný azalttýk
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

        if (Hunger <= 0)
        {
            Hunger = 0f;
            Player.GetComponent<ActionScript>().Health -= 1*Time.deltaTime;
        }

    }
}
