using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool attack;
    public bool triggered;
    public int collectedwoods;
    public GameObject log;
     GameObject collidedobject;
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && triggered == true)
        {

            collidedobject.GetComponent<treehealt>().tree_healt -= 1;
            
            
        }
        else
        {

            collidedobject.GetComponent<treehealt>().tree_healt -= 0;
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
}
