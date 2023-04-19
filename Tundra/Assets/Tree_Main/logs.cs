using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class logs : MonoBehaviour
{
     ActionScript P;
    // Start is called before the first frame update
    void Start()
    {
       P=GameObject.Find("FirstPersonController").GetComponent<ActionScript>();
        
    }


    private void Update()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Player")
        {

            P.collectedwoods += 3;
            P.AddedCanvas.SetActive(true);
            Destroy(gameObject);
        }
    }
}
