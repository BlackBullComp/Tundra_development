using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takethelogonhand : MonoBehaviour
{

    ActionScript P;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("FirstPersonController").GetComponent<ActionScript>();
        P.LogPref.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            P.armanimator.SetBool("wood", true);
                P.Axe.SetActive(false);
            P.logsactive = true;
                Destroy(gameObject);
            
        }
        else
        {
            P.Axe.SetActive(true);
            P.logsactive = false;
        }
    }
}
