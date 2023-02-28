using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullstartupdelay : MonoBehaviour
{

    float delay = 2f;
    public GameObject bull_img;
    public string level_name;
    // Start is called before the first frame update
    void Start()
    {
        bull_img.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if (delay <= 0)
        {
            delay= 0;
            bull_img.SetActive(false);
            Application.LoadLevel(level_name);
        }
    }
}
