using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider HealthBar;
    public bool attack;
    public bool triggered;
    public int collectedwoods;
    public GameObject log;
    public GameObject Barscanvas;
    float hunger;
    float thirstyplayer;
    
     GameObject collidedobject;
    public float Health = 100;
    void Start()
    {
        hunger = Barscanvas.GetComponent<hungrybarscript>().Hunger;
        thirstyplayer = Barscanvas.GetComponent<ThirstyBar>().thirsty;
    }

    // Update is called once per frame
    

    void Update()
    {
        HealthBar.value = Health;
        
        if (Input.GetMouseButtonDown(0) && triggered == true)
        {

            collidedobject.GetComponent<treehealt>().tree_healt -= 1;
            
            
        }
       

        if (hunger <= 0 && thirstyplayer <= 0)
        {
           Die();
        }

        if (Health == 0)
        {
            Die();
        }

    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "water")
        {
            Application.LoadLevel(Application.loadedLevel);
        }


    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.tag == "Tree")
            {

            Debug.Log("collided");
            collidedobject = other.gameObject;
            triggered = true;
                
            }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {

            Debug.Log("exited_c");
            collidedobject = other.gameObject;
            triggered = false;

        }
    }


    public void SpawnLog()
    {
        Instantiate(log, collidedobject.gameObject.transform.position, Quaternion.Euler(-90, 5, 0));
        collectedwoods += 3;
    }

    public void Die()
    {
        Debug.Log("dead");
    }
}
