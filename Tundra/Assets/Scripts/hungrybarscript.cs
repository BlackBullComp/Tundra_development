using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hungrybarscript : MonoBehaviour
{
    
    public Image HungerSlider;

    float percent;
    public GameObject Player;

    public float Hunger;
    float maxHunger = 100f;
    void Start()
    {
        Hunger = maxHunger;
    }

    
    void Update()
    {
        percent = Hunger / 100;
        //deðerin oyun ýcýnde degýsecegý ýcýn buraya yazýyoruz.
        HungerSlider.fillAmount = percent;
        Hunger -= 0.5f* Time.deltaTime;

        //açlýk barýný azalttýk
        if(Input.GetKey(KeyCode.W))
            { Hunger -= 0.6f * Time.deltaTime; }
        if (Input.GetKey(KeyCode.A))
        { Hunger -= 0.6f * Time.deltaTime; }
        if (Input.GetKey(KeyCode.S))
        { Hunger -= 0.6f * Time.deltaTime; }
        if (Input.GetKey(KeyCode.D))
        { Hunger -= 0.6f * Time.deltaTime; }

        if (Input.GetKey(KeyCode.LeftShift))
        { Hunger -= 1f * Time.deltaTime; }

        if (Input.GetKeyDown(KeyCode.Space))
        { Hunger -= 1.5f; }

        if (Hunger <= 0)
        {
            Hunger = 0f;
            Player.GetComponent<ActionScript>().Health -= 1*Time.deltaTime;
            Player.GetComponent<FirstPersonController>().enableSprint= false;        
            Player.GetComponent<FirstPersonController>().useSprintBar= false;        
            Player.GetComponent<FirstPersonController>().enableJump= false;        
            if (Player.GetComponent<ActionScript>().Health <= 0)
            {
                Player.GetComponent<ActionScript>().Health = 0;
                Player.GetComponent<ActionScript>().Die();
            }
        }
        else
        {

            Player.GetComponent<FirstPersonController>().enableSprint = true;
            Player.GetComponent<FirstPersonController>().useSprintBar = true;
            Player.GetComponent<FirstPersonController>().enableJump = true;
        }

    }
}
