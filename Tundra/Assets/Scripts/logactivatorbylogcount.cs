using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logactivatorbylogcount : MonoBehaviour
{
    ActionScript scriptofPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
           scriptofPlayer = GameObject.Find("FirstPersonController").GetComponent<ActionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scriptofPlayer.collectedlogs += 1;
            Destroy(gameObject);
        }
    }
}
