using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    // Start is called before the first frame update

    public bool attack;
    public int collectedwoods;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            attack= true;
        }
        else
        {
            attack= false;
        }
    }


}
